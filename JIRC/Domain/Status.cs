using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JIRC.Domain
{
    public class Status : BasicStatus
    {
        public string Description { get; set; }

        public Uri IconUrl { get; set; }
    }
}
