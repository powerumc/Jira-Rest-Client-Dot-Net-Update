// --------------------------------------------------------------------------------------------------------------------
// <copyright file="JiraSessionRestClient.cs" company="David Bevin">
//   Copyright (c) David Bevin.
// </copyright>
// <summary>
//   Defines the JiraSessionRestClient type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

using JIRC.Domain;

using ServiceStack.ServiceClient.Web;

namespace JIRC.Clients
{
    internal class JiraSessionRestClient : ISessionRestClient
    {
        private readonly JsonServiceClient client;

        private readonly Uri serverUri;

        public JiraSessionRestClient(JsonServiceClient client, Uri serverUri)
        {
            this.client = client;
            this.serverUri = serverUri;
        }

        public Session GetCurrentSession()
        {
            var uri = new Uri(serverUri, "/rest/auth/latest/session");
            return client.Get<Session>(uri.ToString());
        }
    }
}
