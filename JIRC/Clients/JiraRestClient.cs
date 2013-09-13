// -----------------------------------------------------------------------
// <copyright file="JiraRestClient.cs" company="David Bevin">
//     Copyright (c) David Bevin.
// </copyright>
// -----------------------------------------------------------------------

using System;

using JIRC.Domain;
using JIRC.Internal;

using ServiceStack.ServiceClient.Web;

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

            IssueClient = new JiraIssueRestClient(client);
            ProjectClient = new JiraProjectRestClient(client);
            SearchClient = new JiraSearchRestClient(client);
        }

        public IIssueRestClient IssueClient { get; private set; }

        public IProjectRestClient ProjectClient { get; private set; }

        public ISearchRestClient SearchClient { get; private set; }

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
