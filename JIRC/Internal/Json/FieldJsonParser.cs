using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using JIRC.Domain;

using ServiceStack.Common.Extensions;
using ServiceStack.Text;

namespace JIRC.Internal.Json
{
    internal static class FieldJsonParser
    {
        public static IEnumerable<Field> Parse(JsonArrayObjects json)
        {
            return json.ConvertAll(x => new Field
            {
                Id = x.Get("id"),
                Name = x.Get("name"),
                Orderable = x.Get<bool>("orderable"),
                Navigable = x.Get<bool>("navigable"),
                Searchable = x.Get<bool>("searchable"),
                FieldType = x.Get<bool>("custom") ? Field.Type.Custom : Field.Type.Jira,
                Schema = x.Get<FieldSchema>("schema")
            });
        }
    }
}
