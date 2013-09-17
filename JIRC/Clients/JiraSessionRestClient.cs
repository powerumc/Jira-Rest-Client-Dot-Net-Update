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
using JIRC.Internal.Json;

using ServiceStack.ServiceClient.Web;
using ServiceStack.Text;

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
            var json = client.Get<JsonObject>(uri.ToString());
            return SessionJsonParser.Parse(json);
        }
    }
}
