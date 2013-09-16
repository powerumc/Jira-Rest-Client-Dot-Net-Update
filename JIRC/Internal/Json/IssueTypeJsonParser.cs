using System;

using JIRC.Domain;

using ServiceStack.Text;

namespace JIRC.Internal.Json
{
    internal static class IssueTypeJsonParser
    {
        internal static IssueType Parse(JsonObject json)
        {
            var basicIssueType = BasicIssueTypeJsonParser.Parse(json);
            var iconUrl = json.Get<Uri>("iconUrl");
            var description = json.Get("description");
            return new IssueType(basicIssueType.Self, basicIssueType.Id, basicIssueType.Name, basicIssueType.Subtask, description, iconUrl);
        }
    }
}
