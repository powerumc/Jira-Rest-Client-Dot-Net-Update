using System;
using System.Collections.Generic;

using JIRC.Domain;

using ServiceStack.Text;

namespace JIRC.Internal.Json
{
    internal static class CimProjectJsonParser
    {
        internal static CimProject Parse(JsonObject json)
        {
            var basicProject = BasicProjectJsonParser.Parse(json);
            var issueTypes = json.ArrayObjects("issuetypes").ConvertAll(CimIssueTypeJsonParser.Parse);
            var avatarUris = json.Get<Dictionary<string, Uri>>("avatarUrls");
            return new CimProject(basicProject.Self, basicProject.Key, basicProject.Name, avatarUris, issueTypes);
        }
    }
}
