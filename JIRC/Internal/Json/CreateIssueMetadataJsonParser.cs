using System.Collections.Generic;

using JIRC.Domain;

using ServiceStack.Text;

namespace JIRC.Internal.Json
{
    internal static class CreateIssueMetadataJsonParser
    {
        internal static IEnumerable<CimProject> Parse(JsonObject json)
        {
            return json.Get<IEnumerable<CimProject>>("projects");
        }
    }
}
