using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JIRC.Domain
{
    public class Priority : BasicPriority
    {
        // TODO: Convert to a colour object?
        public string StatusColor { get; set; }

        public string Description { get; set; }

        public Uri IconUrl { get; set; }
    }
}
