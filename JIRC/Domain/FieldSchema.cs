using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace JIRC.Domain
{
    public class FieldSchema
    {
        public string Type { get; set; }

        public string Items { get; set; }

        public string System { get; set; }

        public string Custom { get; set; }

        public int CustomId { get; set; }
    }
}
