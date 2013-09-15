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
            var helper = new ComponentInputWithProjectKey(projectKey, componentInput);
            var json = ComponentInputWithProjectKeyJsonGenerator.Generate(helper);
            var response = client.Post<JsonObject>(baseComponentUri.ToString(), json);
            return ComponentJsonParser.Parse(response);
        }

        public Component UpdateComponent(Uri componentUri, ComponentInput componentInput)
        {
            var helper = new ComponentInputWithProjectKey(null, componentInput);
            var json = ComponentInputWithProjectKeyJsonGenerator.Generate(helper);
            var response = client.Put<JsonObject>(componentUri.ToString(), json);
            return ComponentJsonParser.Parse(response);
        }

        public void RemoveComponent(Uri componentUri)
        {
            RemoveComponent(componentUri, null);
        }

        public void RemoveComponent(Uri componentUri, Uri moveIssueToComponentUri)
        {
            var qb = new UriBuilder(componentUri);
            if (moveIssueToComponentUri != null)
            {
                qb.AppendQuery("moveIssuesTo", moveIssueToComponentUri.ToString());
            }

            client.Delete<JsonObject>(qb.Uri.ToString());
        }

        public int GetComponentRelatedIssuesCount(Uri componentUri)
        {
            var uri = componentUri.Append("relatedIssueCounts");
            var json = client.Get<JsonObject>(uri.ToString());
            return json.Get<int>("issueCount");
        }
    }
}
