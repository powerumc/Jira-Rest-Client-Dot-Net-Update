using System;

using JIRC.Domain;

using ServiceStack.Text;

namespace JIRC.Internal.Json
{
    internal static class VersionJsonParser
    {
        internal static JiraVersion Parse(JsonObject json)
        {
            return new JiraVersion
            {
                Archived = json.Get<bool>("archived"),
                Description = json.Get("description"),
                Id = json.Get<long>("id"),
                Name = json.Get("name"),
                ReleaseDate = json.Get<DateTimeOffset>("releaseDate"),
                Released = json.Get<bool>("released"),
                Self = json.Get<Uri>("self")
            };
        }
    }
}
