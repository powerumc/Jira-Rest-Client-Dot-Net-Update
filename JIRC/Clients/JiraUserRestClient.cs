using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using JIRC.Domain;
using JIRC.Extensions;

using ServiceStack.ServiceClient.Web;
using ServiceStack.Text;

namespace JIRC.Clients
{
    internal class JiraUserRestClient : IUserRestClient
    {
        private const string UserUriPrefix = "/user";

        private readonly JsonServiceClient client;

        public JiraUserRestClient(JsonServiceClient client)
        {
            this.client = client;
        }

        public User GetUser(string username)
        {
            var qb = new UriBuilder(client.BaseUri.AppendPath(UserUriPrefix));
            qb.AppendQuery("username", username);
            qb.AppendQuery("expand", "groups");

            return GetUser(qb.Uri);
        }

        public User GetUser(Uri userUri)
        {
            return client.Get<User>(userUri.ToString());
        }
    }
}
