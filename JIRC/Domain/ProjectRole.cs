using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JIRC.Domain
{
    public class ProjectRole : BasicProjectRole
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public IEnumerable<RoleActor> Actors { get; set; }
    }
}
