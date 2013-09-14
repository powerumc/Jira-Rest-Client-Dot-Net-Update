using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JIRC.Domain
{
    public class IssueLinkType
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public LinkDirection Direction { get; set; }

        public enum LinkDirection
        {
            Outbound,
            Inbound
        }
    }
}
