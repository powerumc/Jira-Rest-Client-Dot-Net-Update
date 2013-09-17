
using System;

namespace JIRC.Domain
{
    public class Component : BasicComponent
    {
        public Component(Uri self, long? id, string name, string description, BasicUser lead)
            :this(self, id, name, description, lead, null)
        {
        }

        public Component(Uri self, long? id, string name, string description, BasicUser lead, AssigneeInfo assigneeInfo)
            : base(self, id, name, description)
        {
            Lead = lead;
            AssigneeInfo = assigneeInfo;
        }

        public BasicUser Lead { get; private set; }

        public AssigneeInfo AssigneeInfo { get; private set; }
    }
}
