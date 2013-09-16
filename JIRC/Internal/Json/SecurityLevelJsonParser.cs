using System;

using JIRC.Domain;

using ServiceStack.Text;

namespace JIRC.Internal.Json
{
    internal static class SecurityLevelJsonParser
    {
        internal static SecurityLevel Parse(JsonObject json)
        {
            return new SecurityLevel { Name = json.Get("name"), Description = json.Get("description"), Id = json.Get<long>("id"), Self = json.Get<Uri>("self") };
        }
    }
}
