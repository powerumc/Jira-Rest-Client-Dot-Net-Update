using System.Collections.Generic;

using JIRC.Domain.Input;

namespace JIRC.Internal.Json.Gen
{
    internal class Dummy
    {
        private readonly Dictionary<string, object> f = new Dictionary<string, object>();

        public Dictionary<string, object> fields
        {
            get
            {
                return f;
            }
        }
    }

    internal class IssueInputJsonGenerator
    {
        internal static object Generate(IssueInput issue)
        {
            var jsonObject = new Dummy();

            if (issue != null && issue.Fields != null)
            {
                foreach (var f in issue.Fields.Values)
                {
                    if (f.Value != null)
                    {
                        jsonObject.fields.Add(f.Id, ComplexIssueInputFieldValueJsonGenerator.GenerateFieldValueForJson(f.Value));
                    }
                }
            }

            return jsonObject;
        }
    }
}
