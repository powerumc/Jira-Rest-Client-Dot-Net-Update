// -----------------------------------------------------------------------
// <copyright file="JiraRestClientFactory.cs" company="David Bevin">
//     Copyright (c) David Bevin.
// </copyright>
// -----------------------------------------------------------------------

using System;

using JIRC.Clients;

namespace JIRC
{
    /// <summary>
    /// A factory for creating JIRA clients.
    /// </summary>
    public class JiraRestClientFactory : IJiraRestClientFactory
    {
        /// <summary>
        /// Creates a new JIRA client using Basic Authentication. You really should use HTTPS when you do this.
        /// </summary>
        /// <param name="serverUri">The base URI of the JIRA instance.</param>
        /// <param name="username">The username to use.</param>
        /// <param name="password">The password to use.</param>
        /// <returns>A new client for accessing JIRA.</returns>
        public IJiraRestClient CreateWithBasicHttpAuth(Uri serverUri, string username, string password)
        {
            return new JiraRestClient(serverUri, username, password);
        }

        /// <summary>
        /// Creates a new JIRA client using anonymous access.
        /// </summary>
        /// <param name="serverUri">The base URI of the JIRA instance.</param>
        /// <returns>A new client for accessing JIRA.</returns>
        public IJiraRestClient CreateWithAnonymous(Uri serverUri)
        {
            return new JiraRestClient(serverUri);
        }
    }
}
