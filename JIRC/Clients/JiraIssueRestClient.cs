﻿// -----------------------------------------------------------------------
// <copyright file="JiraIssueRestClient.cs" company="David Bevin">
//     Copyright (c) David Bevin.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

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
    /// <summary>
    /// The REST client for issues in JIRA.
    /// </summary>
    internal class JiraIssueRestClient : IIssueRestClient
    {
        private const string IssuesUriPrefix = "issue";

        private const string CommentUriPostfix = "comment";

        private readonly JsonServiceClient client;

        private readonly IMetadataRestClient metadataClient;

        private readonly ISessionRestClient sessionClient;

        private ServerInfo serverInfo;

        /// <summary>
        /// Initializes a new instance of the issue REST client.
        /// </summary>
        /// <param name="client">The JSON client that has been set up for a specific JIRA instance.</param>
        /// <param name="metadataClient">The metadata REST client for the same JIRA instance.</param>
        /// <param name="sessionClient">The session REST client for the same JIRA instance.</param>
        public JiraIssueRestClient(JsonServiceClient client, IMetadataRestClient metadataClient, ISessionRestClient sessionClient)
        {
            this.client = client;
            this.metadataClient = metadataClient;
            this.sessionClient = sessionClient;
        }

        /// <summary>
        /// Creates an issue or a subtask.
        /// </summary>
        /// <param name="issue">Information about the issue to create. The fields that can be set on issue creation can be determined using the <see cref="IIssueRestClient.GetCreateIssueMetadata()"/> or <see cref="IIssueRestClient.GetCreateIssueMetadata(JIRC.Domain.Input.GetCreateIssueMetadataOptions)"/> methods.
        /// The <see cref="IssueInputBuilder"/> class can be used to help generate the appropriate fields.</param>
        /// <seealso cref="IssueInputBuilder"/>
        /// <returns>Details of the created issue.</returns>
        /// <exception cref="WebException">The input is invalid (e.g. missing required fields, invalid field values, and so forth), or if the calling user does not have permission to create the issue.</exception>
        public BasicIssue CreateIssue(IssueInput issue)
        {
            var json = IssueInputJsonGenerator.Generate(issue);
            return client.Post<BasicIssue>("issue", json);
        }

        /// <summary>
        /// Returns the meta data for creating issues.
        /// This includes the available projects, issue types and fields, including field types and whether or not those fields are required. Projects will not be returned if the user does not have permission to create issues in that project.</summary>
        /// <returns>A collection of fields for each project that corresponds with fields in the create screen for each project/issue type.</returns>
        /// <exception cref="WebException">The caller is not logged in, or does not have permission to view any projects.</exception>
        public IEnumerable<CimProject> GetCreateIssueMetadata()
        {
            return GetCreateIssueMetadata(null);
        }

        /// <summary>
        /// Returns the meta data for creating issues.
        /// This includes the available projects, issue types and fields, including field types and whether or not those fields are required. Projects will not be returned if the user does not have permission to create issues in that project.</summary>
        /// <param name="options">A set of options that allow the project/field/issue types to be constrained. The <see cref="GetCreateIssueMetadataOptionsBuilder"/> class can be used to help generate the appropriate request.</param>
        /// <seealso cref="GetCreateIssueMetadataOptionsBuilder"/>
        /// <returns>A collection of fields for each project that corresponds with fields in the create screen for each project/issue type.</returns>
        /// <exception cref="WebException">The caller is not logged in, or does not have permission to view any of the requested projects.</exception>
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

        /// <summary>
        /// Creates many issue or subtasks in one bulk operation.
        /// </summary>
        /// <param name="issues">The collection of issues or subtasks to create.</param>
        /// <returns>Information about the created issue (including URIs), or error information.</returns>
        /// <exception cref="WebException">The caller is not logged in, or does not have permission to create issues in the specified projects.</exception>
        public BulkOperationResult<BasicIssue> CreateIssues(IList<IssueInput> issues)
        {
            var json = IssuesInputJsonGenerator.Generate(issues);
            return client.Post<BulkOperationResult<BasicIssue>>("issue/bulk", json);
        }

        /// <summary>
        /// Gets the issue specified by the unique key (e.g. "AA-123").
        /// </summary>
        /// <param name="key">The unique key for the issue.</param>
        /// <returns>Information about the issue.</returns>
        /// <exception cref="WebException">The requested issue is not found, or the user does not have permission to view it.</exception>
        public Issue GetIssue(string key)
        {
            var json = client.Get<JsonObject>("/{0}/{1}".Fmt(IssuesUriPrefix, key));
            return IssueJsonParser.Parse(json);
        }

        /// <summary>
        /// Delete an issue.
        /// If the issue has subtasks you must set the parameter <see cref="deleteSubtasks"/> to delete the issue. You cannot delete an issue without its subtasks also being deleted.
        /// </summary>
        /// <param name="issueKey">The unique key of the issue to delete.</param>
        /// <param name="deleteSubtasks">Must be set to true if the issue has subtasks.</param>
        /// <exception cref="WebException">The requested issue is not found, or the user does not have permission to delete it.</exception>
        public void DeleteIssue(string issueKey, bool deleteSubtasks)
        {
            var qb = new UriBuilder(client.BaseUri);
            qb.Path = qb.Path.AppendPath("issue", issueKey);
            qb.AppendQuery("deleteSubtasks", deleteSubtasks.ToString().ToLower());
            client.Delete<JsonObject>(qb.Uri.ToString());
        }

        /// <summary>
        /// Gets details about the users who are watching the specified issue.
        /// </summary>
        /// <param name="watchersUri">URI of the watchers resource for the selected issue. Usually obtained by getting the <see cref="BasicWatchers.Self"/> property on the <see cref="Issue"/>.</param>
        /// <returns>The list of watchers for the issue with the given URI.</returns>
        /// <exception cref="WebException">The requested watcher URI is not found, or the user does not have permission to view it.</exception>
        public Watchers GetWatchers(Uri watchersUri)
        {
            var json = client.Get<JsonObject>(watchersUri.ToString());
            return WatchersJsonParser.Parse(json);
        }

        /// <summary>
        /// Gets details about the users who have voted for the specified issue.
        /// </summary>
        /// <param name="votesUri">URI of the voters resource for the selected issue. Usually obtained by getting the <see cref="BasicVotes.Self"/> property on the <see cref="Issue"/>.</param>
        /// <returns>The list of voters for the issue with the given URI.</returns>
        /// <exception cref="WebException">The requested voter URI is not found, or the user does not have permission to view it.</exception>
        public Votes GetVotes(Uri votesUri)
        {
            return client.Get<Votes>(votesUri.ToString());
        }

        /// <summary>
        /// Get a list of the transitions possible for this issue by the current user, along with fields that are required and their types.
        /// </summary>
        /// <param name="transitionsUri">URI of transitions resource of selected issue. Usually obtained by getting the <see cref="Issue.TransitionsUri"/> property.</param>
        /// <returns>Transition information about the transitions available for the selected issue in its current state.</returns>
        /// <exception cref="WebException">The requested transition URI is not found, or the user does not have permission to view it.</exception>
        public IEnumerable<Transition> GetTransitions(Uri transitionsUri)
        {
            var qb = new UriBuilder(transitionsUri);
            qb.AppendQuery("expand", "transitions.fields");

            var json = client.Get<JsonObject>(qb.Uri.ToString());
            return TransitionJsonParser.Parse(json);
        }

        /// <summary>
        /// Get a list of the transitions possible for this issue by the current user, along with fields that are required and their types.
        /// </summary>
        /// <param name="issue">The issue on which to obtain the available transitions for.</param>
        /// <returns>Transition information about the transitions available for the selected issue in its current state.</returns>
        /// <exception cref="WebException">The requested issue is not found, or the user does not have permission to view it.</exception>
        public IEnumerable<Transition> GetTransitions(Issue issue)
        {
            if (issue.TransitionsUri != null)
            {
                return GetTransitions(issue.TransitionsUri);
            }

            var uri = issue.Self.Append("transitions");
            return GetTransitions(uri);
        }

        /// <summary>
        /// Perform a transition on an issue. When performing the transition you can update or set other issue fields.
        /// </summary>
        /// <param name="transitionsUri">URI of transitions resource of selected issue. Usually obtained by getting the <see cref="Issue.TransitionsUri"/> property.</param>
        /// <param name="transitionInput">Information about the transition to perform.</param>
        /// <exception cref="WebException">There is no transition specified, or the requested issue is not found, or the user does not have permission to view it.</exception>
        public void Transition(Uri transitionsUri, TransitionInput transitionInput)
        {
            var json = TransitionInputJsonGenerator.Generate(transitionInput, GetServerInfo());
            client.Post<JsonObject>(transitionsUri.ToString(), json);
        }

        /// <summary>
        /// Perform a transition on an issue. When performing the transition you can update or set other issue fields.
        /// </summary>
        /// <param name="issue">The issue on which to obtain the available transitions for.</param>
        /// <param name="transitionInput">Information about the transition to perform.</param>
        /// <exception cref="WebException">There is no transition specified, or the requested issue is not found, or the user does not have permission to view it.</exception>
        public void Transition(Issue issue, TransitionInput transitionInput)
        {
            Transition(issue.TransitionsUri ?? issue.Self.Append("transitions"), transitionInput);
        }

        /// <summary>
        /// Casts your vote on the selected issue. Casting a vote on already votes issue by the caller, causes the exception.
        /// </summary>
        /// <param name="votesUri">URI of the voters resource for the selected issue. Usually obtained by getting the <see cref="BasicVotes.Self"/> property on the <see cref="Issue"/>.</param>
        /// <exception cref="WebException">If the user cannot vote for any reason. (The user is the reporter, the user does not have permission to vote, voting is disabled in the instance, the issue does not exist, etc.).</exception>
        public void Vote(Uri votesUri)
        {
            client.Post<JsonObject>(votesUri.ToString(), null);
        }

        /// <summary>
        ///  Removes your vote from the selected issue. Removing a vote from the issue without your vote causes the exception.
        /// </summary>
        /// <param name="votesUri">URI of the voters resource for the selected issue. Usually obtained by getting the <see cref="BasicVotes.Self"/> property on the <see cref="Issue"/>.</param>
        /// <exception cref="WebException">If the user cannot remove a vote for any reason. (The user did not vote on the issue, the user is the reporter, voting is disabled, the issue does not exist, etc.).</exception>
        public void Unvote(Uri votesUri)
        {
            client.Delete<JsonObject>(votesUri.ToString());
        }

        /// <summary>
        /// Starts watching selected issue.
        /// </summary>
        /// <param name="watchersUri">URI of the watchers resource for the selected issue. Usually obtained by getting the <see cref="BasicWatchers.Self"/> property on the <see cref="Issue"/>.</param>
        /// <exception cref="WebException">If the issue does not exist, or the the calling user does not have permission to watch the issue.</exception>
        public void Watch(Uri watchersUri)
        {
            client.Post<JsonObject>(watchersUri.ToString(), null);
        }

        /// <summary>
        /// Stops watching selected issue.
        /// </summary>
        /// <param name="watchersUri">URI of the watchers resource for the selected issue. Usually obtained by getting the <see cref="BasicWatchers.Self"/> property on the <see cref="Issue"/>.</param>
        /// <exception cref="WebException">If the issue does not exist, or the the calling user does not have permission to watch the issue.</exception>
        public void Unwatch(Uri watchersUri)
        {
            RemoveWatcher(watchersUri, GetLoggedUsername());
        }

        /// <summary>
        /// Adds selected person as a watcher for selected issue.
        /// </summary>
        /// <param name="watchersUri">URI of the watchers resource for the selected issue. Usually obtained by getting the <see cref="BasicWatchers.Self"/> property on the <see cref="Issue"/>.</param>
        /// <param name="username">The user to add as a watcher.</param>
        /// <exception cref="WebException">If the issue does not exist, or the the calling user does not have permission to modifier watchers of the issue.</exception>
        public void AddWatcher(Uri watchersUri, string username)
        {
            var json = new JsonValue(username);
            client.Post<JsonObject>(watchersUri.ToString(), json);
        }

        /// <summary>
        /// Removes selected person as a watcher for selected issue.
        /// </summary>
        /// <param name="watchersUri">URI of the watchers resource for the selected issue. Usually obtained by getting the <see cref="BasicWatchers.Self"/> property on the <see cref="Issue"/>.</param>
        /// <param name="username">The user to remove as a watcher.</param>
        /// <exception cref="WebException">If the issue does not exist, or the the calling user does not have permission to modifier watchers of the issue.</exception>
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

        /// <summary>
        /// Creates link between two issues and adds a comment (optional) to the source issues.
        /// </summary>
        /// <param name="linkIssuesInput">Details for the link and the comment (optional) to be created.</param>
        /// <exception cref="WebException">If there was a problem linking the issues, or the the calling user does not have permission to link issues.</exception>
        public void LinkIssue(LinkIssuesInput linkIssuesInput)
        {
            client.Post<JsonObject>("issueLink", LinkIssuesInputJsonGenerator.Generate(linkIssuesInput, GetServerInfo()));
        }

        /// <summary>
        /// Adds a comment to the specified issue.
        /// </summary>
        /// <param name="issue">The  issue to add the comment to.</param>
        /// <param name="comment">The comment to add to the issue.</param>
        /// <exception cref="WebException">If the issue does not exist, or the the calling user does not have permission to comment on the issue.</exception>
        public void AddComment(BasicIssue issue, Comment comment)
        {
            var uri = issue.Self.Append(CommentUriPostfix);
            var request = CommentJsonGenerator.Generate(comment, GetServerInfo());
            client.Post<Comment>(uri.ToString(), request);
        }

        /// <summary>
        /// Adds a comment to the specified issue.
        /// </summary>
        /// <param name="commentsUri">The URI for the issue to add the comment to.</param>
        /// <param name="comment">The comment to add to the issue.</param>
        /// <exception cref="WebException">If the issue does not exist, or the the calling user does not have permission to comment on the issue.</exception>
        public void AddComment(Uri commentsUri, Comment comment)
        {
            var request = CommentJsonGenerator.Generate(comment, GetServerInfo());
            var response = client.Post<Comment>(commentsUri.ToString(), request);
            response.PrintDump();
        }

        /// <summary>
        /// Adds a new work log entry to issue.
        /// </summary>
        /// <param name="worklogUri">The URI for the work log resource for the selected issue.</param>
        /// <param name="worklogInput">The work log information to add to the issue.</param>
        /// <exception cref="WebException">If the issue does not exist, or the the calling user does not have permission to add work log information to the issue.</exception>
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
