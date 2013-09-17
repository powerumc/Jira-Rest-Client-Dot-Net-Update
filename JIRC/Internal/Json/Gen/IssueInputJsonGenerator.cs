﻿using System.Collections.Generic;
using System.Linq;

using JIRC.Domain.Input;

using ServiceStack.Text;

namespace JIRC.Internal.Json.Gen
{
    internal class IssueInputJsonGenerator
    {
        internal static JsonObject Generate(IssueInput issue)
        {
            var jsonObject = new JsonObject();
            var list = new Dictionary<string, object>();

            if (issue != null && issue.Fields != null)
            {
                foreach (var f in issue.Fields.Values.Where(f => f.Value != null))
                {
                    list.Add(f.Id, ComplexIssueInputFieldValueJsonGenerator.GenerateFieldValueForJson(f.Value));
                }
            }

            jsonObject.Add("fields", list.ToJson());
            return jsonObject;
        }
    }
}
