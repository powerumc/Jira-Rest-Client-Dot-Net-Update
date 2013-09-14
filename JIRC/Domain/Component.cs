using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JIRC.Domain
{
    public class Component : BasicComponent
    {
        public BasicUser Lead { get; set; }

        public AssigneeInfo AssigneeInfo { get; set; }
    }
}
