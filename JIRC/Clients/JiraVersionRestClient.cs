using System;

using JIRC.Domain;
using JIRC.Domain.Input;
using JIRC.Extensions;
using JIRC.Internal.Json;
using JIRC.Internal.Json.Gen;

using ServiceStack.ServiceClient.Web;
using ServiceStack.Text;

namespace JIRC.Clients
{
    internal class JiraVersionRestClient : IVersionRestClient
    {
        private readonly Uri baseVersionUri;

        private readonly JsonServiceClient client;

        public JiraVersionRestClient(JsonServiceClient client)
        {
            this.client = client;
            baseVersionUri = new Uri(client.BaseUri).Append("version");
        }

        public JiraVersion GetVersion(Uri versionUri)
        {
            return client.Get<JiraVersion>(versionUri.ToString());
        }

        public JiraVersion CreateVersion(VersionInput versionInput)
        {
            var json = VersionInputJsonGenerator.Generate(versionInput);
            return client.Post<JiraVersion>(baseVersionUri.ToString(), json);
        }

        public JiraVersion UpdateVersion(Uri versionUri, VersionInput versionInput)
        {
            var json = VersionInputJsonGenerator.Generate(versionInput);
            return client.Put<JiraVersion>(versionUri.ToString(), json);
        }

        public void RemoveVersion(Uri versionUri)
        {
            RemoveVersion(versionUri, null, null);
        }

        public void RemoveVersion(Uri versionUri, Uri moveFixIssuesToVersionUri, Uri moveAffectedIssuesToVersionUri)
        {
            var qb = new UriBuilder(versionUri);
            if (moveFixIssuesToVersionUri != null)
            {
                qb.AppendQuery("moveFixIssuesTo", moveFixIssuesToVersionUri.ToString());
            }

            if (moveAffectedIssuesToVersionUri != null)
            {
                qb.AppendQuery("moveAffectedIssuesTo", moveAffectedIssuesToVersionUri.ToString());
            }

            client.Delete<JsonObject>(qb.Uri.ToString());
        }

        public VersionRelatedIssuesCount GetVersionRelatedIssuesCount(Uri versionUri)
        {
            var json = client.Get<JsonObject>(GetRelatedIssuesCountUri(versionUri));
            return VersionRelatedIssuesCountJsonParser.Parse(json);
        }

        public int GetNumUnresolvedIssues(Uri versionUri)
        {
            return client.Get<int>(GetUnresolvedIssueCountUri(versionUri));
        }

        public JiraVersion MoveVersionAfter(Uri versionUri, Uri afterVersionUri)
        {
            var json = new JsonObject { { "after", afterVersionUri.ToString() } };
            return client.Post<JiraVersion>(GetMoveVersionUri(versionUri), json);
        }

        public JiraVersion MoveVersion(Uri versionUri, VersionPosition versionPosition)
        {
            var json = VersionPositionInputJsonGenerator.Generate(versionPosition);
            return client.Post<JiraVersion>(GetMoveVersionUri(versionUri), json);
        }

        private static string GetRelatedIssuesCountUri(Uri versionUri)
        {
            return versionUri.Append("relatedIssuesCount").ToString();
        }

        private static string GetUnresolvedIssueCountUri(Uri versionUri)
        {
            return versionUri.Append("unresolvedIssueCount").ToString();
        }

        private static string GetMoveVersionUri(Uri versionUri)
        {
            return versionUri.Append("move").ToString();
        }
    }
}
