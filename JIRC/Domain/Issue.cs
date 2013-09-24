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
        public Issue()
        {
            Attachments = new Attachment[0];
        }

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
        public Uri TransitionsUri { get; internal set; }

        public BasicWatchers Watchers { get; set; }

        public BasicVotes Votes { get; set; }
        public IEnumerable<JiraVersion> AffectedVersions { get; set; }
        public User Assignee { get; set; }
        public IEnumerable<Attachment> Attachments { get; internal set; }
    }
}
