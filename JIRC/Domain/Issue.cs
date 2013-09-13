// -----------------------------------------------------------------------
// <copyright file="Issue.cs" company="David Bevin">
//     Copyright (c) David Bevin.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;

using JIRC.Extensions;

namespace JIRC.Domain
{
    public class Issue : BasicIssue
    {
        public IEnumerable<JiraVersion> AffectedVersions { get; set; }
        public User Assignee { get; set; }

        public Uri CommentsUri
        {
            get
            {
                return Self != null ? Self.Append("comment") : null;
            }
        }

        public string Description { get; set; }
        public IEnumerable<JiraVersion> FixVersions { get; set; }

        public BasicProject Project { get; set; }

        public User Reporter { get; set; }
        public string Summary { get; set; }
        public Uri TransitionsUri { get; set; }
    }
}
