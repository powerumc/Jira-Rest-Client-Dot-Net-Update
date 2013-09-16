using System;

using JIRC.Domain;

using ServiceStack.Text;

namespace JIRC.Internal.Json
{
    internal static class BasicResolutionJsonParser
    {
        internal static BasicResolution Parse(JsonObject json)
        {
            return new BasicResolution { Name = json.Get("name"), Self = json.Get<Uri>("self") };
        }
    }
}
