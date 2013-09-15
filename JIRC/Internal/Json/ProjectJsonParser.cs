using System;
using System.Collections.Generic;

using JIRC.Domain;

using ServiceStack.Common.Extensions;
using ServiceStack.Text;

namespace JIRC.Internal.Json
{
    internal static class ProjectJsonParser
    {
        public static Project Parse(JsonObject json)
        {
            var project = new Project
            {
                Id = json.Get<int>("id"),
                Key = json.Get("key"),
                Name = json.Get("name"),
                Self = json.Get<Uri>("self"),
                Description = json.Get("description"),
                Lead = json.Get<BasicUser>("lead"),
                Url = json.Get<Uri>("url"),

                Versions = json.ArrayObjects("versions").ConvertAll(x => new JiraVersion
                {
                    Id = x.Get<int>("id"),
                    Name = x.Get("name"),
                    Description = x.Get("description"),
                    Self = x.Get<Uri>("self"),
                    Archived = x.Get<bool>("archived"),
                    Released = x.Get<bool>("released"),
                    ReleaseDate = x.Get<DateTimeOffset>("releasedate")
                }),

                Components = json.ArrayObjects("components").ConvertAll(x => new BasicComponent
                {
                    Id = x.Get<int>("id"),
                    Description = x.Get("description"),
                    Name = x.Get("name"),
                    Self = x.Get<Uri>("self")
                }),

                Roles = json.Get<Dictionary<string, Uri>>("roles").ConvertAll(x => new BasicProjectRole
                {
                    Name = x.Key,
                    Self = x.Value
                })
            };

            return project;
        }
    }
}
