
using System.Collections.Generic;

namespace JIRC.Domain.Input
{
    public class ComplexIssueInputFieldValue
    {
        private readonly IDictionary<string, object> values;

        public ComplexIssueInputFieldValue(IDictionary<string, object> values)
        {
            this.values = values;
        }

        public static ComplexIssueInputFieldValue With(string key, object value)
        {
            var dict = new Dictionary<string, object> { { key, value } };
            return new ComplexIssueInputFieldValue(dict);
        }

        public IDictionary<string, object> ValuesMap
        {
            get
            {
                return values;
            }
        }
    }
}
