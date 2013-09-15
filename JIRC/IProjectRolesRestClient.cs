using System;
using System.Collections.Generic;

using JIRC.Domain;

namespace JIRC
{
    public interface IProjectRolesRestClient
    {
        ProjectRole GetRole(Uri uri);

        ProjectRole GetRole(Uri projectUri, int roleId);

        IEnumerable<BasicProjectRole> GetRoles(Uri projectUri);
    }
}
