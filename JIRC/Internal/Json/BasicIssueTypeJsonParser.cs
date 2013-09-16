using System;

using JIRC.Domain;

using ServiceStack.Text;

namespace JIRC.Internal.Json
{
    internal static class BasicIssueTypeJsonParser
    {
        internal static BasicIssueType Parse(JsonObject json)
        {
            return new BasicIssueType(json.Get<Uri>("self"), json.Get<long>("id"), json.Get("name"), json.Get<bool>("subtask"));
        }
    }
}
