using System;

using JIRC.Domain;

using ServiceStack.Text;

namespace JIRC.Internal.Json
{
    internal static class LoginInfoJsonParser
    {
        internal static LoginInfo Parse(JsonObject json)
        {
            return new LoginInfo
            {
                FailedLoginCount = json.Get<int>("failedLoginCount"),
                LoginCount = json.Get<int>("loginCount"),
                LastFailedLoginDate = json.Get<DateTime>("lastFailedLoginTime"),
                PreviousLoginDate = json.Get<DateTime>("previousLoginTime")
            };
        }
    }
}
