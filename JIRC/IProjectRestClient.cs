// -----------------------------------------------------------------------
// <copyright file="IProjectRestClient.cs" company="David Bevin">
//     Copyright (c) David Bevin.
// </copyright>
// -----------------------------------------------------------------------

using System.Collections.Generic;

using JIRC.Domain;

namespace JIRC
{
    public interface IProjectRestClient
    {
        IEnumerable<BasicProject> GetAllProjects();

        Project GetProject(string key);
    }
}
