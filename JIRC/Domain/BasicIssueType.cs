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
        public Uri Self { get; set; }

        public int Id { get; set; }

        public string Name { get; set; }

        public bool Subtask { get; set; }
    }
}
