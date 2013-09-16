using System;
using System.Collections.Generic;

namespace JIRC.Domain
{
    public class CimProject : BasicProject
    {
        public CimProject(Uri self, string key, string name, Dictionary<string, Uri> avatarUris, IEnumerable<CimIssueType> issueTypes)
            : base(self, key, name)
        {
            AvatarUris = avatarUris;
            IssueTypes = issueTypes;
        }

        public Dictionary<string, Uri> AvatarUris { get; set; }

        public IEnumerable<CimIssueType> IssueTypes { get; set; }
    }
}
