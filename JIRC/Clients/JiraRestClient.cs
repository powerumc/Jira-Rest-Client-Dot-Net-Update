// -----------------------------------------------------------------------
// <copyright file="JiraRestClient.cs" company="David Bevin">
//     Copyright (c) David Bevin.
// </copyright>
// -----------------------------------------------------------------------

using System;

using JIRC.Domain;
using JIRC.Internal;
using JIRC.Internal.Json;

using ServiceStack.ServiceClient.Web;
using ServiceStack.Text;

namespace JIRC.Clients
{
    public class JiraRestClient : IJiraRestClient
    {
        private const string LatestRestUri = "/rest/api/latest";

        private readonly JsonServiceClient client;

        private readonly string pass;

        private readonly Uri serverUri;

        private readonly string user;

        private SessionInfo cookie;

        public JiraRestClient(Uri serverUri, string user, string pass)
        {
            var baseUri = new Uri(serverUri, LatestRestUri);
            client = new JsonServiceClient(baseUri.ToString());

            this.serverUri = serverUri;
            this.user = user;
            this.pass = pass;

            SessionClient = new JiraSessionRestClient(client, serverUri);
            UserClient = new JiraUserRestClient(client);
            ProjectClient = new JiraProjectRestClient(client);
            ComponentClient = new JiraComponentRestClient(client);
            MetadataClient = new JiraMetadataRestClient(client);
            SearchClient = new JiraSearchRestClient(client);
            VersionClient = new JiraVersionRestClient(client);
            ProjectRolesClient = new JiraProjectRolesRestClient(client);
            IssueClient = new JiraIssueRestClient(client, MetadataClient, SessionClient);
        }

        static JiraRestClient()
        {
            JsConfig.DateHandler = JsonDateHandler.ISO8601;

            CustomJsonSerializer.RegisterAllClasses();
        }

        public IIssueRestClient IssueClient { get; private set; }

        public ISessionRestClient SessionClient { get; private set; }

        public IUserRestClient UserClient { get; private set; }

        public IProjectRestClient ProjectClient { get; private set; }

        public IComponentRestClient ComponentClient { get; private set; }

        public IMetadataRestClient MetadataClient { get; private set; }

        public ISearchRestClient SearchClient { get; private set; }

        public IVersionRestClient VersionClient { get; private set; }

        public IProjectRolesRestClient ProjectRolesClient { get; private set; }

        public void ClearSession()
        {
            cookie = null;
            client.Headers.Clear();
        }

        public SessionInfo Login()
        {
            var req = new SessionPost { username = user, password = pass };
            var uri = new Uri(serverUri, "/rest/auth/1/session");
            var response = client.Post<SessionInfo>(uri.ToString(), req);

            cookie = response;
            client.Headers.Clear();
            client.Headers.Add("Cookie", string.Format("{0}={1}", cookie.Session.Name, cookie.Session.Value));

            return response;
        }

        public void Logout()
        {
            // TODO: Logout session
            //client.Delete("/rest/auth/1/session");
        }
    }
}
