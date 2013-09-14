using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JIRC.Domain
{
    public class IssueLinksType : AddressableNamedEntity
    {
        public string Id { get; set; }

        public string Inward { get; set; }

        public string Outward { get; set; }
    }
}
