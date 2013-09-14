using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using JIRC.Domain;
using JIRC.Domain.Input;
using JIRC.Extensions;
using JIRC.Internal.Json;

using ServiceStack.ServiceClient.Web;
using ServiceStack.Text;

namespace JIRC.Clients
{
    internal class JiraComponentRestClient : IComponentRestClient
    {
        private readonly JsonServiceClient client;

        private readonly Uri baseComponentUri;

        public JiraComponentRestClient(JsonServiceClient client)
        {
            this.client = client;
            baseComponentUri = new Uri(client.BaseUri).Append("component");
        }

        public Component GetComponent(Uri componentUri)
        {
            var json = client.Get<JsonObject>(componentUri.ToString());
            return ComponentJsonParser.Parse(json);
        }

        public Component CreateComponent(string projectKey, ComponentInput componentInput)
        {
            throw new NotImplementedException();
        }

        public Component UpdateComponent(Uri componentUri, ComponentInput componentInput)
        {
            throw new NotImplementedException();
        }

        public void RemoveComponent(Uri componentUri)
        {
            throw new NotImplementedException();
        }

        public void RemoveComponent(Uri componentUri, Uri moveIssueToComponentUri)
        {
            throw new NotImplementedException();
        }

        public int GetComponentRelatedIssuesCount(Uri componentUri)
        {
            var uri = componentUri.Append("relatedIssueCounts");
            var json = client.Get<JsonObject>(uri.ToString());
            return json.Get<int>("issueCount");
        }
    }
}
