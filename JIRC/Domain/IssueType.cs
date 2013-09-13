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
        public string Description { get; set; }

        public Uri IconUri { get; set; }
    }
}
