// -----------------------------------------------------------------------
// <copyright file="JiraIssueRestClient.cs" company="David Bevin">
//     Copyright (c) David Bevin.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;

using JIRC.Domain;
using JIRC.Domain.Input;
using JIRC.Extensions;
using JIRC.Internal;
using JIRC.Internal.Json;
using JIRC.Internal.Json.Gen;

using ServiceStack.ServiceClient.Web;
using ServiceStack.Text;

namespace JIRC.Clients
{
    internal class JiraIssueRestClient : IIssueRestClient
    {
        private const string IssuesUriPrefix = "issue";

        private const string CommentUriPostfix = "comment";

        private readonly JsonServiceClient client;

        private readonly IMetadataRestClient metadataClient;

        private readonly ISessionRestClient sessionClient;

        private ServerInfo serverInfo;

        public JiraIssueRestClient(JsonServiceClient client, IMetadataRestClient metadataClient, ISessionRestClient sessionClient)
        {
            this.client = client;
            this.metadataClient = metadataClient;
            this.sessionClient = sessionClient;
        }

        public BasicIssue CreateIssue(IssueInput issue)
        {
            var json = IssueInputJsonGenerator.Generate(issue);
            return client.Post<BasicIssue>("issue", json);
        }

        public IEnumerable<CimProject> GetCreateIssueMetadata()
        {
            return GetCreateIssueMetadata(null);
        }

        public IEnumerable<CimProject> GetCreateIssueMetadata(GetCreateIssueMetadataOptions options)
        {
            var qb = new UriBuilder(client.BaseUri);
            qb.Path = qb.Path.AppendPath("issue", "createmeta");

            if (options != null)
            {
                if (options.ProjectIds != null && options.ProjectIds.Any())
                {
                    qb.AppendQuery("projectIds", options.ProjectIds.Join(","));
                }

                if (options.ProjectKeys != null && options.ProjectKeys.Any())
                {
                    qb.AppendQuery("projectKeys", options.ProjectKeys.Join(","));
                }

                if (options.IssueTypeIds != null && options.IssueTypeIds.Any())
                {
                    qb.AppendQuery("issuetypeIds", options.IssueTypeIds.Join(","));
                }

                if (options.IssueTypeName != null)
                {
                    foreach (var i in options.IssueTypeName)
                    {
                        qb.AppendQuery("issuetypeNames", i);
                    }
                }

                if (options.Expandos != null && options.Expandos.Any())
                {
                    qb.AppendQuery("expand", options.Expandos.Join(","));
                }
            }

            var json = client.Get<JsonObject>(qb.Uri.ToString());
            return CreateIssueMetadataJsonParser.Parse(json);
        }

        public BulkOperationResult<BasicIssue> CreateIssues(IList<IssueInput> issues)
        {
            var json = IssuesInputJsonGenerator.Generate(issues);
            return client.Post<BulkOperationResult<BasicIssue>>("issue/bulk", json);
        }

        public Issue GetIssue(string key)
        {
            var json = client.Get<JsonObject>("/{0}/{1}".Fmt(IssuesUriPrefix, key));
            return IssueJsonParser.Parse(json);
        }

        public void DeleteIssue(string issueKey, bool deleteSubtasks)
        {
            var qb = new UriBuilder(client.BaseUri);
            qb.Path = qb.Path.AppendPath("issue", issueKey);
            qb.AppendQuery("deleteSubtasks", deleteSubtasks.ToString().ToLower());
            client.Delete<JsonObject>(qb.Uri.ToString());
        }

        public Watchers GetWatchers(Uri watchersUri)
        {
            var json = client.Get<JsonObject>(watchersUri.ToString());
            return WatchersJsonParser.Parse(json);
        }

        public Votes GetVotes(Uri votesUri)
        {
            return client.Get<Votes>(votesUri.ToString());
        }

        public IEnumerable<Transition> GetTransitions(Uri transitionsUri)
        {
            var qb = new UriBuilder(transitionsUri);
            qb.AppendQuery("expand", "transitions.fields");

            var json = client.Get<JsonObject>(qb.Uri.ToString());
            return TransitionJsonParser.Parse(json);
        }

        public IEnumerable<Transition> GetTransitions(Issue issue)
        {
            if (issue.TransitionsUri != null)
            {
                return GetTransitions(issue.TransitionsUri);
            }

            var uri = issue.Self.Append("transitions");
            return GetTransitions(uri);
        }

        public void Transition(Uri transitionsUri, TransitionInput transitionInput)
        {
            var json = TransitionInputJsonGenerator.Generate(transitionInput, GetServerInfo());
            client.Post<JsonObject>(transitionsUri.ToString(), json);
        }

        public void Transition(Issue issue, TransitionInput transitionInput)
        {
            Transition(issue.TransitionsUri ?? issue.Self.Append("transitions"), transitionInput);
        }

        public void Vote(Uri votesUri)
        {
            client.Post<JsonObject>(votesUri.ToString(), null);
        }

        public void Unvote(Uri votesUri)
        {
            client.Delete<JsonObject>(votesUri.ToString());
        }

        public void Watch(Uri watchersUri)
        {
            client.Post<JsonObject>(watchersUri.ToString(), null);
        }

        public void Unwatch(Uri watchersUri)
        {
            RemoveWatcher(watchersUri, GetLoggedUsername());
        }

        public void AddWatcher(Uri watchersUri, string username)
        {
            var json = new JsonValue(username);
            client.Post<JsonObject>(watchersUri.ToString(), json);
        }

        public void RemoveWatcher(Uri watchersUri, string username)
        {
            var qb = new UriBuilder(watchersUri);
            if (GetServerInfo().BuildNumber >= ServerVersionConstants.BuildNumberJira44)
            {
                qb.AppendQuery("username", username);
            }
            else
            {
                qb.Path.AppendPath(username);
            }

            client.Delete<JsonObject>(qb.Uri.ToString());
        }

        public void LinkIssue(LinkIssuesInput linkIssuesInput)
        {
            client.Post<JsonObject>("issueLink", LinkIssuesInputJsonGenerator.Generate(linkIssuesInput, GetServerInfo()));
        }

        public void AddComment(BasicIssue issue, Comment comment)
        {
            var uri = issue.Self.Append(CommentUriPostfix);
            var request = CommentJsonGenerator.Generate(comment, GetServerInfo());
            client.Post<Comment>(uri.ToString(), request);
        }

        public void AddComment(Uri commentsUri, Comment comment)
        {
            var request = CommentJsonGenerator.Generate(comment, GetServerInfo());
            var response = client.Post<Comment>(commentsUri.ToString(), request);
            response.PrintDump();
        }

        public void AddWorklog(Uri worklogUri, WorklogInput worklogInput)
        {
            var qb = new UriBuilder(worklogUri);
            qb.AppendQuery("adjustEstimate", worklogInput.AdjustEstimate.ToString().ToLower());

            switch (worklogInput.AdjustEstimate)
            {
                case WorklogInput.AdjustmentEstimate.New:
                    qb.AppendQuery("newEstimate", worklogInput.AdjustEstimateValue.NullToEmpty());
                    break;

                case WorklogInput.AdjustmentEstimate.Manual:
                    qb.AppendQuery("reduceBy", worklogInput.AdjustEstimateValue.NullToEmpty());
                    break;
            }

            client.Post<JsonObject>(qb.Uri.ToString(), WorklogInputJsonGenerator.Generate(worklogInput));
        }

        private ServerInfo GetServerInfo()
        {
            return serverInfo ?? (serverInfo = metadataClient.GetServerInfo());
        }

        private string GetLoggedUsername()
        {
            return sessionClient.GetCurrentSession().UserName;
        }
    }
}
