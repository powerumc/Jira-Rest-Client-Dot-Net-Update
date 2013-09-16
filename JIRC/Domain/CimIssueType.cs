using System;
using System.Collections.Generic;

namespace JIRC.Domain
{
    public class CimIssueType : IssueType
    {
        public CimIssueType(Uri self, long? id, string name, bool isSubtask, string description, Uri iconUrl, Dictionary<string, CimFieldInfo> fields)
            : base(self, id, name, isSubtask, description, iconUrl)
        {
            Fields = fields;
        }

        public Dictionary<string, CimFieldInfo> Fields { get; private set; }

        public CimFieldInfo GetField(IssueFieldId fieldId)
        {
            CimFieldInfo info;
            Fields.TryGetValue(fieldId.ToRestString(), out info);
            return info;
        }
    }
}
