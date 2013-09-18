// -----------------------------------------------------------------------
// <copyright file="IJiraRestClientFactory.cs" company="David Bevin">
//     Copyright (c) David Bevin.
// </copyright>
// -----------------------------------------------------------------------

using System;

namespace JIRC
{
    /// <summary>
    /// An interface for a factory for generating JIRA REST clients.
    /// </summary>
    public interface IJiraRestClientFactory
    {
        /// <summary>
        /// Creates a new JIRA client using Basic Authentication. You really should use HTTPS when you do this.
        /// </summary>
        /// <param name="serverUri">The base URI of the JIRA instance.</param>
        /// <param name="username">The username to use.</param>
        /// <param name="password">The password to use.</param>
        /// <returns>A new client for accessing JIRA.</returns>
        IJiraRestClient CreateWithBasicHttpAuth(Uri serverUri, string username, string password);

        /// <summary>
        /// Creates a new JIRA client using anonymous access.
        /// </summary>
        /// <param name="serverUri">The base URI of the JIRA instance.</param>
        /// <returns>A new client for accessing JIRA.</returns>
        IJiraRestClient CreateWithAnonymous(Uri serverUri);
    }
}
