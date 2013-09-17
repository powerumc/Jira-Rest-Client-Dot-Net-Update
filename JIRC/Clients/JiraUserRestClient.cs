using System;
using System.Collections.Generic;

using JIRC.Domain;
using JIRC.Extensions;

using ServiceStack.ServiceClient.Web;
using ServiceStack.Text;

namespace JIRC.Clients
{
    internal class JiraUserRestClient : IUserRestClient
    {
        private const string UserUriPrefix = "/user";

        private const string UserAssignableSearchUriPrefix = "/user/assignable/search";

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

        public IEnumerable<User> GetAssignableUsers(BasicProject project)
        {
            return GetAssignableUsersForProject(project.Key, null, null);
        }

        public IEnumerable<User> GetAssignableUsers(BasicProject project, int? startAt, int? maxResults)
        {
            return GetAssignableUsersForProject(project.Key, startAt, maxResults);
        }

        public IEnumerable<User> GetAssignableUsers(BasicIssue issue)
        {
            return GetAssignableUsersForIssue(issue.Key, null, null);
        }

        public IEnumerable<User> GetAssignableUsers(BasicIssue issue, int startAt, int maxResults)
        {
            return GetAssignableUsersForIssue(issue.Key, null, null);
        }

        public IEnumerable<User> GetAssignableUsersForProject(string projectKey)
        {
            return GetAssignableUsersForProject(projectKey, null, null);
        }

        public IEnumerable<User> GetAssignableUsersForProject(string projectKey, int? startAt, int? maxResults)
        {
            var qb = new UriBuilder(client.BaseUri.AppendPath(UserAssignableSearchUriPrefix));
            qb.AppendQuery("project", projectKey);

            if (maxResults != null)
            {
                qb.AppendQuery("maxResults", maxResults.ToString());
            }

            if (startAt != null)
            {
                qb.AppendQuery("startAt", startAt.ToString());
            }

            return client.Get<IEnumerable<User>>(qb.Uri.ToString());
        }

        public IEnumerable<User> GetAssignableUsersForIssue(string issueKey)
        {
            return GetAssignableUsersForIssue(issueKey, null, null);
        }

        public IEnumerable<User> GetAssignableUsersForIssue(string issueKey, int? startAt, int? maxResults)
        {
            var qb = new UriBuilder(client.BaseUri.AppendPath(UserAssignableSearchUriPrefix));
            qb.AppendQuery("issueKey", issueKey);

            if (maxResults != null)
            {
                qb.AppendQuery("maxResults", maxResults.ToString());
            }

            if (startAt != null)
            {
                qb.AppendQuery("startAt", startAt.ToString());
            }

            return client.Get<IEnumerable<User>>(qb.Uri.ToString());
        }
    }
}
