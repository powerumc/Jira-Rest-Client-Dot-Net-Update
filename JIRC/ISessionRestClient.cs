// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ISessionRestClient.cs" company="David Bevin">
//   Copyright (c) David Bevin.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using JIRC.Domain;

using ServiceStack.ServiceClient.Web;

namespace JIRC
{
    /// <summary>
    /// An interface for obtaining information about login sessions.
    /// </summary>
    public interface ISessionRestClient
    {
        /// <summary>
        /// Gets information about the current session.
        /// </summary>
        /// <returns>Information about the session.</returns>
        /// <exception cref="WebServiceException">There was a problem accessing the server.</exception>
        Session GetCurrentSession();
    }
}
