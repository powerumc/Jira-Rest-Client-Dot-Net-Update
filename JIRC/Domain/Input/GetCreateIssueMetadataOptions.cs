using System.Collections.Generic;

namespace JIRC.Domain.Input
{
    public class GetCreateIssueMetadataOptions
    {
        public const string ExpandProjectsIssueTypesFields = "projects.issuetypes.fields";

        public GetCreateIssueMetadataOptions(
            IEnumerable<string> expandos,
            IEnumerable<string> issueTypeName,
            IEnumerable<long> issueTypeIds,
            IEnumerable<string> projectKeys,
            IEnumerable<long> projectIds)
        {
            Expandos = expandos;
            IssueTypeName = issueTypeName;
            IssueTypeIds = issueTypeIds;
            ProjectKeys = projectKeys;
            ProjectIds = projectIds;
        }

        public IEnumerable<string> Expandos { get; private set; }

        public IEnumerable<string> IssueTypeName { get; private set; }

        public IEnumerable<long> IssueTypeIds { get; private set; }

        public IEnumerable<string> ProjectKeys { get; private set; }

        public IEnumerable<long> ProjectIds { get; private set; }
    }
}
