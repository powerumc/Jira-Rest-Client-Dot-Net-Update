// -----------------------------------------------------------------------
// <copyright file="IJiraRestClientFactory.cs" company="David Bevin">
//     Copyright (c) David Bevin.
// </copyright>
// -----------------------------------------------------------------------

using System;

namespace JIRC
{
    public interface IJiraRestClientFactory
    {
        IJiraRestClient CreateWithBasicHttpAuth(Uri serverUri, string username, string password);
    }
}
