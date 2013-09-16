using JIRC.Domain;

using ServiceStack.Text;

namespace JIRC.Internal.Json.Gen
{
    internal static class VisibilityJsonGenerator
    {
        internal static JsonObject Generate(Visibility visibility)
        {
            return new JsonObject { { "type", visibility.Type.ToString().ToLower() }, { "value", visibility.Value }, };
        }
    }
}
