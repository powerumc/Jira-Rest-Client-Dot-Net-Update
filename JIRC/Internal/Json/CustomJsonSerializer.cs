using System;
using System.Collections.Generic;

using JIRC.Domain;

using ServiceStack.Common.Extensions;
using ServiceStack.Text;

namespace JIRC.Internal.Json
{
    internal class CustomJsonSerializer
    {
        internal static void RegisterAllClasses()
        {
            // TODO: Generate this at initialisation time from methods!
            JsConfig<BasicResolution>.RawDeserializeFn = a => BasicResolutionJsonParser(JsonObject.Parse(a));
            JsConfig<BasicUser>.RawDeserializeFn = a => BasicUserJsonParser(JsonObject.Parse(a));
            JsConfig<User>.RawDeserializeFn = a => UserJsonParser(JsonObject.Parse(a));
            JsConfig<SecurityLevel>.RawDeserializeFn = a => SecurityLevelJsonParser(JsonObject.Parse(a));
            JsConfig<IEnumerable<IssueLinksType>>.RawDeserializeFn = a => IssueLinkTypesJsonParser(JsonObject.Parse(a));
            JsConfig<BasicPriority>.RawDeserializeFn = a => BasicPriorityJsonParser(JsonObject.Parse(a));
            JsConfig<Component>.RawDeserializeFn = a => ComponentJsonParser(JsonObject.Parse(a));
            JsConfig<BasicProject>.RawDeserializeFn = a => BasicProjectJsonParser(JsonObject.Parse(a));
            JsConfig<Project>.RawDeserializeFn = a => ProjectJsonParser(JsonObject.Parse(a));
            JsConfig<CimProject>.RawDeserializeFn = a => CimProjectJsonParser(JsonObject.Parse(a));
            JsConfig<JiraVersion>.RawDeserializeFn = a => JiraVersionJsonParser(JsonObject.Parse(a));
            JsConfig<BasicVotes>.RawDeserializeFn = a => BasicVotesJsonParser(JsonObject.Parse(a));
        }

        internal static BasicResolution BasicResolutionJsonParser(JsonObject json)
        {
            return new BasicResolution(json.Get<Uri>("self"), json.Get("name"));
        }

        internal static SecurityLevel SecurityLevelJsonParser(JsonObject json)
        {
            return new SecurityLevel(json.Get<Uri>("self"), json.Get<long>("id"), json.Get("name"), json.Get("description"));
        }

        internal static JiraVersion JiraVersionJsonParser(JsonObject json)
        {
            return new JiraVersion
            {
                Archived = json.Get<bool>("archived"),
                Description = json.Get("description"),
                Id = json.Get<long>("id"),
                Name = json.Get("name"),
                ReleaseDate = json.Get<DateTimeOffset>("releaseDate"),
                Released = json.Get<bool>("released"),
                Self = json.Get<Uri>("self")
            };
        }

        private static BasicUser BasicUserJsonParser(JsonObject json)
        {
            return new BasicUser(json.Get<Uri>("self"), json.Get("name"), json.Get("displayName"));
        }

        private static User UserJsonParser(JsonObject json)
        {
            var avatars = json.Get<Dictionary<string, Uri>>("avatarUrls");
            var basic = BasicUserJsonParser(json);
            var active = !json.ContainsKey("active") || json.Get<bool>("active");
            var timezone = json.Get("timeZone");
            return new User(basic, json.Get("emailAddress"), null, avatars, active, timezone);
        }

        private static IEnumerable<IssueLinksType> IssueLinkTypesJsonParser(JsonObject json)
        {
            return json.Get<IEnumerable<IssueLinksType>>("issueLinkTypes");
        }

        internal static BasicPriority BasicPriorityJsonParser(JsonObject json)
        {
            return new BasicPriority(json.Get<Uri>("self"), json.Get<long>("id"), json.Get("name"));
        }

        private static CimProject CimProjectJsonParser(JsonObject json)
        {
            var basicProject = BasicProjectJsonParser(json);
            var issueTypes = json.ArrayObjects("issuetypes").ConvertAll(CimIssueTypeJsonParser.Parse);
            var avatarUris = json.Get<Dictionary<string, Uri>>("avatarUrls");
            return new CimProject(basicProject.Self, basicProject.Key, basicProject.Name, avatarUris, issueTypes);
        }

        internal static BasicProject BasicProjectJsonParser(JsonObject json)
        {
            return new BasicProject(json.Get<Uri>("self"), json.Get("key"), json.Get("name"));
        }

        private static BasicVotes BasicVotesJsonParser(JsonObject json)
        {
            return new BasicVotes(json.Get<Uri>("self"), json.Get<int>("votes"), json.Get<bool>("hasVoted"));
        }

        private static Project ProjectJsonParser(JsonObject json)
        {
            return new Project(
                json.Get<Uri>("self"),
                json.Get("key"),
                json.Get("name"),
                json.Get("description"),
                json.Get<BasicUser>("lead"),
                json.Get<Uri>("url"),
                json.Get<IEnumerable<JiraVersion>>("versions"),
                json.Get<IEnumerable<Component>>("components"),
                null,
                json.Get<Dictionary<string, Uri>>("roles").ConvertAll(x => new BasicProjectRole { Name = x.Key, Self = x.Value }));
        }

        internal static Component ComponentJsonParser(JsonObject json)
        {
            var assigneeTypeStr = json.Get("assigneeType");
            AssigneeInfo assignee = null;
            if (assigneeTypeStr != null)
            {
                assignee = new AssigneeInfo
                {
                    AssigneeType = ParseAssigneeType(json.Get("assigneeType")),
                    Assignee = json.Get<BasicUser>("assignee"),
                    RealAssigneeType = ParseAssigneeType(json.Get("realAssigneeType")),
                    RealAssignee = json.Get<BasicUser>("realAssignee"),
                    AssigneeTypeValid = json.Get<bool>("isAssigneeTypeValid")
                };
            }

            return new Component(json.Get<Uri>("self"), json.Get<long>("id"), json.Get("name"), json.Get("description"), json.Get<BasicUser>("lead"), assignee);
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
