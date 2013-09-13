// -----------------------------------------------------------------------
// <copyright file="JiraRestClientFactory.cs" company="David Bevin">
//     Copyright (c) David Bevin.
// </copyright>
// -----------------------------------------------------------------------

using System;

using JIRC.Clients;

namespace JIRC
{
    public class JiraRestClientFactory : IJiraRestClientFactory
    {
        public IJiraRestClient CreateWithBasicHttpAuth(Uri serverUri, string username, string password)
        {
            return new JiraRestClient(serverUri, username, password);
        }
    }
}
