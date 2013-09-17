using System.Collections.Generic;

using JIRC.Domain.Input;

using ServiceStack.Common.Extensions;
using ServiceStack.Text;

namespace JIRC.Internal.Json.Gen
{
    internal static class IssuesInputJsonGenerator
    {
        internal static JsonObject Generate(IList<IssueInput> issues)
        {
            var jsonObject = new JsonObject();
            var list = new List<JsonObject>();

            if (issues != null)
            {
                list = issues.ConvertAll(IssueInputJsonGenerator.Generate);
            }

            jsonObject.Add("issueUpdates", list.ToJson());
            return jsonObject;
        }
    }
}
