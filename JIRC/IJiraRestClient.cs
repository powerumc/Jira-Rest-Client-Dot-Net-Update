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

        IProjectRestClient ProjectClient { get; }

        ISearchRestClient SearchClient { get; }

        IMetadataRestClient MetadataClient { get; }

        void ClearSession();

        SessionInfo Login();

        void Logout();
    }
}
