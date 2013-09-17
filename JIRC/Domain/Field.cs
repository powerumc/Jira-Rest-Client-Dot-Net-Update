// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Field.cs" company="David Bevin">
//   Copyright (c) David Bevin.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

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
