
using System;

using JIRC.Domain;

using ServiceStack.Text;

namespace JIRC.Internal.Json
{
    internal static class VersionRelatedIssuesCountJsonParser
    {
        internal static VersionRelatedIssuesCount Parse(JsonObject json)
        {
            return new VersionRelatedIssuesCount
            {
                VersionUrl = json.Get<Uri>("self"),
                NumFixedIssues = json.Get<int>("issuesFixedCount"),
                NumAffectedIssues = json.Get<int>("issuesAffectedCount")
            };
        }
    }
}
