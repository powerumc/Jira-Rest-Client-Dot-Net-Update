using System;

namespace JIRC.Domain
{
    public class VersionRelatedIssuesCount
    {
        public Uri VersionUrl { get; set; }

        public int NumFixedIssues { get; set; }

        public int NumAffectedIssues { get; set; }
    }
}
