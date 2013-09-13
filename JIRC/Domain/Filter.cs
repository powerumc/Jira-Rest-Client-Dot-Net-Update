using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JIRC.Domain
{
    public class Filter : AddressableNamedEntity
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public BasicUser Owner { get; set; }

        public Uri ViewUrl { get; set; }

        public Uri SearchUrl { get; set; }

        public string Jql { get; set; }
    }
}
