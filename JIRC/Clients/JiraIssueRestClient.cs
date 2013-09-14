// -----------------------------------------------------------------------
// <copyright file="JiraIssueRestClient.cs" company="David Bevin">
//     Copyright (c) David Bevin.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;

using JIRC.Domain;
using JIRC.Domain.Input;
using JIRC.Extensions;
using JIRC.Internal;
using JIRC.Internal.Json;

using ServiceStack.ServiceClient.Web;
using ServiceStack.Text;

namespace JIRC.Clients
{
    internal class JiraIssueRestClient : IIssueRestClient
    {
        private const string IssuesUriPrefix = "issue";

        private const string CommentUriPostfix = "comment";

        private readonly JsonServiceClient client;

        public JiraIssueRestClient(JsonServiceClient client)
        {
            this.client = client;
        }

        public void AddComment(BasicIssue issue, Comment comment)
        {
            Uri uri = issue.Self.Append(CommentUriPostfix);
            uri.PrintDump();
            var request = new CommentPost { body = comment.Body };
            var response = client.Post<Comment>(uri.ToString(), request);
            response.PrintDump();
        }

        public void AddComment(Uri commentsUri, Comment comment)
        {
            var request = new CommentPost { body = comment.Body };
            var response = client.Post<Comment>(commentsUri.ToString(), request);
            response.PrintDump();
        }

        public Issue GetIssue(string key)
        {
            var json = client.Get<JsonObject>("/{0}/{1}".Fmt(IssuesUriPrefix, key));
            return IssueJsonParser.Parse(json);
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
            throw new NotImplementedException();
        }

        public void Transition(Issue issue, TransitionInput transitionInput)
        {
            throw new NotImplementedException();
        }
    }
}
