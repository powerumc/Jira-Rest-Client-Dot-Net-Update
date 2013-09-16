
using JIRC.Domain;

using ServiceStack.Text;

namespace JIRC.Internal.Json.Gen
{
    internal static class BasicUserJsonGenerator
    {
        internal static JsonObject Generate(BasicUser user)
        {
            return new JsonObject { { "self", user.Self.ToString() }, { "name", user.Name }, { "displayName", user.DisplayName } };
        }
    }
}
