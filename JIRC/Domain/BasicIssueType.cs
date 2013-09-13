// -----------------------------------------------------------------------
// <copyright file="BasicIssueType.cs" company="David Bevin">
//     Copyright (c) David Bevin.
// </copyright>
// -----------------------------------------------------------------------

namespace JIRC.Domain
{
    public class BasicIssueType
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool Subtask { get; set; }
    }
}
