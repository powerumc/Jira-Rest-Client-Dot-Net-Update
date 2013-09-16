using System.Collections.Generic;

using JIRC.Domain;

using ServiceStack.Text;

namespace JIRC.Internal.Json
{
    internal static class CimIssueTypeJsonParser
    {
        internal static CimIssueType Parse(JsonObject json)
        {
            var issueType = IssueTypeJsonParser.Parse(json);
            var fields = json.Get<Dictionary<string, JsonObject>>("fields");
            return new CimIssueType(issueType.Self, issueType.Id, issueType.Name, issueType.Subtask, issueType.Description, issueType.IconUrl, CimFieldsInfoMapJsonParser.Parse(fields));
        }
    }
}
