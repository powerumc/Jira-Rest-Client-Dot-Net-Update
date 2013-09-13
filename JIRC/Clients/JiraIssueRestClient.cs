// -----------------------------------------------------------------------
// <copyright file="JiraIssueRestClient.cs" company="David Bevin">
//     Copyright (c) David Bevin.
// </copyright>
// -----------------------------------------------------------------------

using System;

using JIRC.Domain;
using JIRC.Extensions;
using JIRC.Internal;
using JIRC.Internal.Json;

using ServiceStack.ServiceClient.Web;
using ServiceStack.Text;

namespace JIRC.Clients
{
    internal class JiraIssueRestClient : IIssueRestClient
    {
        private const string CommentUriPrefix = "comment";

        private const string IssuesUriPrefix = "issue";

        private static readonly IssueJsonParser IssueParser = new IssueJsonParser();

        private readonly JsonServiceClient client;

        public JiraIssueRestClient(JsonServiceClient client)
        {
            this.client = client;
        }

        public void AddComment(BasicIssue issue, Comment comment)
        {
            Uri uri = issue.Self.Append(CommentUriPrefix);
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
            return IssueParser.Parse(json);
        }
    }
}
