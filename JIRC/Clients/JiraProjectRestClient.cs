// -----------------------------------------------------------------------
// <copyright file="JiraProjectRestClient.cs" company="David Bevin">
//     Copyright (c) David Bevin.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;

using JIRC.Domain;
using JIRC.Extensions;
using JIRC.Internal.Json;

using ServiceStack.Common.Extensions;
using ServiceStack.ServiceClient.Web;
using ServiceStack.Text;

namespace JIRC.Clients
{
    internal class JiraProjectRestClient : IProjectRestClient
    {
        private const string ProjectUriPrefix = "project";

        private const string ProjectRoleUriPostfix = "role";

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

        public ProjectRole GetRole(Uri uri)
        {
            var json = client.Get<JsonObject>(uri.ToString());
            return ProjectRoleJsonParser.Parse(json);
        }

        public ProjectRole GetRole(Uri projectUri, int roleId)
        {
            var uri = projectUri.Append(ProjectRoleUriPostfix).Append(roleId.ToString());
            var json = client.Get<JsonObject>(uri.ToString());
            return ProjectRoleJsonParser.Parse(json);
        }

        public IEnumerable<BasicProjectRole> GetRoles(Uri projectUri)
        {
            var uri = projectUri.Append(ProjectRoleUriPostfix);
            var json = client.Get<Dictionary<string, Uri>>(uri.ToString());
            return json.ConvertAll(x => new BasicProjectRole
            {
                Name = x.Key,
                Self = x.Value
            });

            // TODO: Go and fetch the full Project Role for each role (this method should return IEnumerable<ProjectRole>)
        }
    }
}
