// --------------------------------------------------------------------------------------------------------------------
// <copyright file="JiraRestClient.cs" company="David Bevin">
//   Copyright (c) 2013 David Bevin.
// </copyright>
// // <summary>
//   https://bitbucket.org/dpbevin/jira-rest-client-dot-net
//   Licensed under the BSD 2-Clause License.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

using JIRC.Internal.Json;

using ServiceStack.ServiceClient.Web;
using ServiceStack.Text;

namespace JIRC.Clients
{
    /// <summary>
    /// The client for accessing JIRA via the REST API.
    /// </summary>
    public class JiraRestClient : IJiraRestClient
    {
        static JiraRestClient()
        {
            JsConfig.DateHandler = JsonDateHandler.ISO8601;

            CustomJsonSerializer.RegisterAllClasses();
        }

        /// <summary>
        /// Initializes a new instance of the REST client for JIRA. This will use Basic Authentication.
        /// </summary>
        /// <param name="serverUri">The base URI for the JIRA instance.</param>
        /// <param name="client">The client to us.</param>
        internal JiraRestClient(Uri serverUri, JsonServiceClient client)
        {
            ServerUri = serverUri;

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

        /// <summary>
        /// Gets the client for accessing Issues.
        /// </summary>
        public IIssueRestClient IssueClient { get; private set; }

        /// <summary>
        /// Gets the client for accessing Session information.
        /// </summary>
        public ISessionRestClient SessionClient { get; private set; }

        /// <summary>
        /// Gets the client for accessing User information.
        /// </summary>
        public IUserRestClient UserClient { get; private set; }

        /// <summary>
        /// Gets the client for accessing Projects.
        /// </summary>
        public IProjectRestClient ProjectClient { get; private set; }

        /// <summary>
        /// Gets the client for accessing Components within Projects.
        /// </summary>
        public IComponentRestClient ComponentClient { get; private set; }

        /// <summary>
        /// Gets the client for accessing Metadata.
        /// </summary>
        public IMetadataRestClient MetadataClient { get; private set; }

        /// <summary>
        /// Gets the client for performing JQL searches.
        /// </summary>
        public ISearchRestClient SearchClient { get; private set; }

        /// <summary>
        /// Gets the client for accessing Versions within Projects.
        /// </summary>
        public IVersionRestClient VersionClient { get; private set; }

        /// <summary>
        /// Gets the client for accessing Project Role information.
        /// </summary>
        public IProjectRolesRestClient ProjectRolesClient { get; private set; }

        /// <summary>
        /// Gets the base URI for the JIRA instance.
        /// </summary>
        public Uri ServerUri { get; private set; }
    }
}
