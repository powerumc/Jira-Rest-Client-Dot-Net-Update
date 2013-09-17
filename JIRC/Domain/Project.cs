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
        // TODO: Expandos!
        public Project(
            Uri self,
            string key,
            string name,
            string description,
            BasicUser lead,
            Uri uri,
            IEnumerable<JiraVersion> versions,
            IEnumerable<BasicComponent> components,
            IEnumerable<IssueType> issueTypes,
            IEnumerable<BasicProjectRole> projectRoles)
            : base(self, key, name)
        {
            Description = description;
            Lead = lead;
            Url = uri;
            Versions = versions;
            Components = components;
            IssueTypes = issueTypes;
            Roles = projectRoles;
        }

        public string Description { get; private set; }

        public BasicUser Lead { get; private set; }

        public Uri Url { get; private set; }

        public IEnumerable<JiraVersion> Versions { get; private set; }

        public IEnumerable<BasicComponent> Components { get; private set; }

        public IEnumerable<IssueType> IssueTypes { get; private set; }

        public IEnumerable<BasicProjectRole> Roles { get; private set; }
    }
}
