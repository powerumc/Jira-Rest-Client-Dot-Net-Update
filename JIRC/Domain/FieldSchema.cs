// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FieldSchema.cs" company="David Bevin">
//   Copyright (c) David Bevin.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

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
