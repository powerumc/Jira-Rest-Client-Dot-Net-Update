using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using JIRC.Domain;

using ServiceStack.Text;

namespace JIRC.Internal.Json
{
    internal static class ComponentJsonParser
    {
        public static Component Parse(JsonObject json)
        {
            var component = new Component
            {
                Id = json.Get<int>("id"),
                Name = json.Get("name"),
                Description = json.Get("description"),
                Self = json.Get<Uri>("self"),
                Lead = json.Get<BasicUser>("lead")
            };

            var assigneeTypeStr = json.Get("assigneeType");
            if (assigneeTypeStr != null)
            {
                component.AssigneeInfo = new AssigneeInfo
                {
                    AssigneeType = ParseAssigneeType(json.Get("assigneeType")),
                    Assignee = json.Get<BasicUser>("assignee"),
                    RealAssigneeType = ParseAssigneeType(json.Get("realAssigneeType")),
                    RealAssignee = json.Get<BasicUser>("realAssignee"),
                    AssigneeTypeValid = json.Get<bool>("isAssigneeTypeValid")
                };
            }

            return component;
        }

        private static AssigneeType ParseAssigneeType(string str)
        {
            if (str == "COMPONENT_LEAD")
            {
                return AssigneeType.ComponentLead;
            }

            if (str == "PROJECT_DEFAULT")
            {
                return AssigneeType.ProjectDefault;
            }

            if (str == "PROJECT_LEAD")
            {
                return AssigneeType.ProjectLead;
            }

            if (str == "UNASSIGNED")
            {
                return AssigneeType.Unassigned;
            }

            throw new ArgumentException("Unexpected value of assignee type [{0}]".Fmt(str), "str");
        }
    }
}
