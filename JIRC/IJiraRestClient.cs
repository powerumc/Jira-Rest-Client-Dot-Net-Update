// -----------------------------------------------------------------------
// <copyright file="IJiraRestClient.cs" company="David Bevin">
//     Copyright (c) David Bevin.
// </copyright>
// -----------------------------------------------------------------------

namespace JIRC
{
    /// <summary>
    /// An interface that provides the various clients for accessing JIRA.
    /// </summary>
    public interface IJiraRestClient
    {
        /// <summary>
        /// Gets the client for accessing Issues.
        /// </summary>
        IIssueRestClient IssueClient { get; }

        /// <summary>
        /// Gets the client for accessing Session information.
        /// </summary>
        ISessionRestClient SessionClient { get; }

        /// <summary>
        /// Gets the client for accessing User information.
        /// </summary>
        IUserRestClient UserClient { get; }

        /// <summary>
        /// Gets the client for accessing Projects.
        /// </summary>
        IProjectRestClient ProjectClient { get; }

        /// <summary>
        /// Gets the client for accessing Components within Projects.
        /// </summary>
        IComponentRestClient ComponentClient { get; }

        /// <summary>
        /// Gets the client for accessing Metadata.
        /// </summary>
        IMetadataRestClient MetadataClient { get; }

        /// <summary>
        /// Gets the client for performing JQL searches.
        /// </summary>
        ISearchRestClient SearchClient { get; }

        /// <summary>
        /// Gets the client for accessing Versions within Projects.
        /// </summary>
        IVersionRestClient VersionClient { get; }

        /// <summary>
        /// Gets the client for accessing Project Role information.
        /// </summary>
        IProjectRolesRestClient ProjectRolesClient { get; }
    }
}
