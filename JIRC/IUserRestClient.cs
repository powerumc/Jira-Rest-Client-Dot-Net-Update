using System;
using System.Collections.Generic;

using JIRC.Domain;

namespace JIRC
{
    public interface IUserRestClient
    {
        User GetUser(string username);

        User GetUser(Uri userUri);

        IEnumerable<User> GetAssignableUsers(BasicProject project);

        IEnumerable<User> GetAssignableUsers(BasicProject project, int? startAt, int? maxResults);

        IEnumerable<User> GetAssignableUsers(BasicIssue issue);

        IEnumerable<User> GetAssignableUsers(BasicIssue issue, int startAt, int maxResults);

        IEnumerable<User> GetAssignableUsersForProject(string projectKey);

        IEnumerable<User> GetAssignableUsersForProject(string projectKey, int? startAt, int? maxResults);

        IEnumerable<User> GetAssignableUsersForIssue(string projectKey);

        IEnumerable<User> GetAssignableUsersForIssue(string projectKey, int? startAt, int? maxResults);
    }
}
