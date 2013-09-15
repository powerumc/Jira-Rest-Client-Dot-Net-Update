using System;
using System.Collections.Generic;

using JIRC.Domain;
using JIRC.Internal.Json;

using ServiceStack.ServiceClient.Web;
using ServiceStack.Text;

namespace JIRC.Clients
{
    internal class JiraMetadataRestClient : IMetadataRestClient
    {
        private const string ServerInfoResource = "/serverInfo";

        private const string IssueTypeResource = "/issuetype";

        private const string IssueLinkTypeResource = "/issueLinkType";

        private const string PriorityResource = "/priority";

        private const string ResolutionResource = "/resolution";

        private const string FieldResource = "/field";

        private readonly JsonServiceClient client;

        public JiraMetadataRestClient(JsonServiceClient client)
        {
            this.client = client;
        }

        public IssueType GetIssueType(Uri uri)
        {
            return client.Get<IssueType>(uri.ToString());
        }

        public IEnumerable<IssueType> GetIssueTypes()
        {
            return client.Get<IEnumerable<IssueType>>(IssueTypeResource);
        }

        public IEnumerable<IssueLinksType> GetIssueLinkTypes()
        {
            var json = client.Get<JsonObject>(IssueLinkTypeResource);
            return IssueLinkTypesJsonParser.Parse(json);
        }

        public Status GetStatus(Uri uri)
        {
            return client.Get<Status>(uri.ToString());
        }

        public Priority GetPriority(Uri uri)
        {
            return client.Get<Priority>(uri.ToString());
        }

        public IEnumerable<Priority> GetPriorities()
        {
            return client.Get<IEnumerable<Priority>>(PriorityResource);
        }

        public Resolution GetResolution(Uri uri)
        {
            return client.Get<Resolution>(uri.ToString());
        }

        public IEnumerable<Resolution> GetResolutions()
        {
            return client.Get<IEnumerable<Resolution>>(ResolutionResource);
        }

        public ServerInfo GetServerInfo()
        {
            return client.Get<ServerInfo>(ServerInfoResource);
        }

        public IEnumerable<Field> GetFields()
        {
            var jsonArray = client.Get<JsonArrayObjects>(FieldResource);
            return FieldJsonParser.Parse(jsonArray);
        }
    }
}
