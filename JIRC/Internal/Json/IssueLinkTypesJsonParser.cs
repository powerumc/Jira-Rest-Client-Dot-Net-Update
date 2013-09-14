using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using JIRC.Domain;

using ServiceStack.Text;

namespace JIRC.Internal.Json
{
    internal static class IssueLinkTypesJsonParser
    {
        public static IEnumerable<IssueLinksType> Parse(JsonObject json)
        {
            return json.Get<IEnumerable<IssueLinksType>>("issueLinkTypes");
        }
    }
}
