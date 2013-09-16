using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using JIRC.Domain.Input;

namespace JIRC.Clients
{
    public class GetCreateIssueMetadataOptionsBuilder
    {
        private List<string> expandos = new List<string>();
        private List<string> issueTypeNames = new List<string>();
        private List<long> issueTypeIds = new List<long>();
        private List<string> projectKeys = new List<string>();
        private List<long> projectIds = new List<long>();

        public GetCreateIssueMetadataOptionsBuilder WithExpandedIssueTypesFields()
        {
            return WithExpandos(GetCreateIssueMetadataOptions.ExpandProjectsIssueTypesFields);
        }

        public GetCreateIssueMetadataOptionsBuilder WithExpandos(params string[] values)
        {
            expandos.AddRange(values);
            return this;
        }

        public GetCreateIssueMetadataOptionsBuilder WithIssueTypeNames(params string[] values)
        {
            issueTypeNames.AddRange(values);
            return this;
        }

        public GetCreateIssueMetadataOptionsBuilder WithIssueTypeIds(params long[] values)
        {
            issueTypeIds.AddRange(values);
            return this;
        }

        public GetCreateIssueMetadataOptionsBuilder WithProjectKeys(params string[] values)
        {
            projectKeys.AddRange(values);
            return this;
        }

        public GetCreateIssueMetadataOptionsBuilder WithProjectIds(params long[] values)
        {
            projectIds.AddRange(values);
            return this;
        }

        public GetCreateIssueMetadataOptions Build()
        {
            return new GetCreateIssueMetadataOptions(expandos, issueTypeNames, issueTypeIds, projectKeys, projectIds);
        }
    }
}
