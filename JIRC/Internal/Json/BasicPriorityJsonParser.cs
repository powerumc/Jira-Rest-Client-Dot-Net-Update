using System;

using JIRC.Domain;

using ServiceStack.Text;

namespace JIRC.Internal.Json
{
    class BasicPriorityJsonParser
    {
        public static BasicPriority Parse(JsonObject json)
        {
            return new BasicPriority { Id = json.Get<long>("id"), Name = json.Get("name"), Self = json.Get<Uri>("self") };
        }
    }
}
