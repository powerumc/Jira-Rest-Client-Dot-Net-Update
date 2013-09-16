// -----------------------------------------------------------------------
// <copyright file="IssueType.cs" company="David Bevin">
//     Copyright (c) David Bevin.
// </copyright>
// -----------------------------------------------------------------------

using System;

namespace JIRC.Domain
{
    public class IssueType : BasicIssueType
    {
        public IssueType(Uri self, long? id, string name, bool isSubtask, string description, Uri iconUrl)
            : base (self, id, name, isSubtask)
        {
            Description = description;
            IconUrl = iconUrl;
        }

        public string Description { get; set; }

        public Uri IconUrl { get; set; }
    }
}
