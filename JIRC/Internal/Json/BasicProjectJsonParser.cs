using System;

using JIRC.Domain;

using ServiceStack.Text;

namespace JIRC.Internal.Json
{
    internal static class BasicProjectJsonParser
    {
        public static BasicProject Parse(JsonObject json)
        {
            return new BasicProject { Id = json.Get<int>("id"), Key = json.Get("key"), Name = json.Get("name"), Self = json.Get<Uri>("self") };
        }
    }
}
