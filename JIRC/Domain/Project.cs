// -----------------------------------------------------------------------
// <copyright file="Project.cs" company="David Bevin">
//     Copyright (c) David Bevin.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace JIRC.Domain
{
    public class Project : BasicProject
    {
        public IEnumerable<BasicComponent> Components { get; set; }
        public string Description { get; set; }
        public IEnumerable<IssueType> IssueTypes { get; set; }

        public BasicUser Lead { get; set; }

        public Uri Url { get; set; }

        public IEnumerable<JiraVersion> Versions { get; set; }

        public IEnumerable<BasicProjectRole> Roles { get; set; }
    }
}
