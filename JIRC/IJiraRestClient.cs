// -----------------------------------------------------------------------
// <copyright file="IJiraRestClient.cs" company="David Bevin">
//     Copyright (c) David Bevin.
// </copyright>
// -----------------------------------------------------------------------

using JIRC.Domain;

namespace JIRC
{
    public interface IJiraRestClient
    {
        IIssueRestClient IssueClient { get; }

        ISessionRestClient SessionClient { get; }

        IUserRestClient UserClient { get; }

        IProjectRestClient ProjectClient { get; }

        IComponentRestClient ComponentClient { get; }

        IMetadataRestClient MetadataClient { get; }

        ISearchRestClient SearchClient { get; }

        IVersionRestClient VersionClient { get; }

        IProjectRolesRestClient ProjectRolesClient { get; }

        void ClearSession();

        SessionInfo Login();

        void Logout();
    }
}
