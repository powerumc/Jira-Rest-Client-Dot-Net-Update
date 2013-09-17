// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IssueLinkType.cs" company="David Bevin">
//   Copyright (c) David Bevin.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

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
