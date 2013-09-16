using JIRC.Domain.Input;
using JIRC.Extensions;

using ServiceStack.Text;

namespace JIRC.Internal.Json.Gen
{
    internal static class WorklogInputJsonGenerator
    {
        internal static JsonObject Generate(WorklogInput worklogInput)
        {
            var json = new JsonObject
            {
                { "self", worklogInput.Self.ToString() },
                { "comment", worklogInput.Comment },
                { "started", worklogInput.StartDate.ToRestString() },
                { "timeSpent", worklogInput.MinutesSpent.ToString() }
            };

            if (worklogInput.Visibility != null)
            {
                json.Add("visibility", VisibilityJsonGenerator.Generate(worklogInput.Visibility).ToString());
            }

            if (worklogInput.Author != null)
            {
                json.Add("author", BasicUserJsonGenerator.Generate(worklogInput.Author).ToString());
            }

            if (worklogInput.UpdateAuthor != null)
            {
                json.Add("updateAuthor", BasicUserJsonGenerator.Generate(worklogInput.UpdateAuthor).ToString());
            }

            return json;
        }
    }
}
