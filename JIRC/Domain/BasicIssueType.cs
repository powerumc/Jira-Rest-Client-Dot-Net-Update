// -----------------------------------------------------------------------
// <copyright file="BasicIssueType.cs" company="David Bevin">
//     Copyright (c) David Bevin.
// </copyright>
// -----------------------------------------------------------------------

using System;

namespace JIRC.Domain
{
    public class BasicIssueType
    {
        public BasicIssueType(Uri self, long? id, string name, bool isSubtask)
        {
            Self = self;
            Id = id;
            Name = name;
            Subtask = isSubtask;
        }

        public Uri Self { get; set; }

        public long? Id { get; set; }

        public string Name { get; set; }

        public bool Subtask { get; set; }
    }
}
