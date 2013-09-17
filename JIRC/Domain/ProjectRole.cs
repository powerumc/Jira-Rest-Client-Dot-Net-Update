// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProjectRole.cs" company="David Bevin">
//   Copyright (c) David Bevin.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;

namespace JIRC.Domain
{
    public class ProjectRole : BasicProjectRole
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public IEnumerable<RoleActor> Actors { get; set; }
    }
}
