using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JIRC.Domain
{
    public class Field
    {
        public enum Type
        {
            Jira,
            Custom
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public Type FieldType { get; set; }

        public bool Orderable { get; set; }

        public bool Navigable { get; set; }

        public bool Searchable { get; set; }

        public FieldSchema Schema { get; set; }
    }
}
