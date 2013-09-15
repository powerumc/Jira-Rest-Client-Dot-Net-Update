using System;

using JIRC.Domain;

using ServiceStack.Text;

namespace JIRC.Internal.Json
{
    internal static class SessionJsonParser
    {
        internal static Session Parse(JsonObject json)
        {
            return new Session { UserUri = json.Get<Uri>("self"), UserName = json.Get("name"), LoginInfo = LoginInfoJsonParser.Parse(json.Get<JsonObject>("loginInfo")) };
        }
    }
}
