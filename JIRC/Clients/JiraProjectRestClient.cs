// -----------------------------------------------------------------------
// <copyright file="JiraProjectRestClient.cs" company="David Bevin">
//     Copyright (c) David Bevin.
// </copyright>
// -----------------------------------------------------------------------

using System.Collections.Generic;

using JIRC.Domain;
using JIRC.Internal.Json;

using ServiceStack.ServiceClient.Web;
using ServiceStack.Text;

namespace JIRC.Clients
{
    internal class JiraProjectRestClient : IProjectRestClient
    {
        private const string ProjectUriPrefix = "project";

        private readonly JsonServiceClient client;

        public JiraProjectRestClient(JsonServiceClient client)
        {
            this.client = client;
        }

        public IEnumerable<BasicProject> GetAllProjects()
        {
            return client.Get<IEnumerable<BasicProject>>("/{0}".Fmt(ProjectUriPrefix));
        }

        public Project GetProject(string key)
        {
            var json = client.Get<JsonObject>("/{0}/{1}".Fmt(ProjectUriPrefix, key));
            return ProjectJsonParser.Parse(json);
        }
    }
}
