using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JIRC.Domain
{
    public class Watchers : BasicWatchers
    {
        public IEnumerable<BasicUser> Users { get; set; }
    }
}
