using System;
using System.Collections.Generic;

namespace JIRC.Domain
{
    public class CimFieldInfo
    {
        public string Id { get; set; }

        public bool Required { get; set; }

        public string Name { get; set; }

        public FieldSchema Schema { get; set; }

        public List<StandardOperation> Operations { get; set; }

        public IEnumerable<object> AllowedValues { get; set; }

        public Uri AutoCompleteUri { get; set; }
    }
}
