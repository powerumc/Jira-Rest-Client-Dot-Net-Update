using System;
using System.Collections.Generic;

using JIRC.Domain;

using ServiceStack.Text;

namespace JIRC.Internal.Json
{
    internal static class ProjectRoleJsonParser
    {
        public static ProjectRole Parse(JsonObject json)
        {
            return new ProjectRole
            {
                Id = json.Get<int>("id"),
                Name = json.Get("key"),
                Description = json.Get("description"),
                Self = json.Get<Uri>("self"),
                Actors = json.Get<IEnumerable<RoleActor>>("actors")
            };
        }
    }
}
