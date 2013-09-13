// -----------------------------------------------------------------------
// <copyright file="IssueJsonParser.cs" company="David Bevin">
//     Copyright (c) David Bevin.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;

using JIRC.Domain;
using JIRC.Extensions;

using ServiceStack.Text;

namespace JIRC.Internal.Json
{
    internal class IssueJsonParser
    {
        public static Issue Parse(JsonObject json)
        {
            var issue = new Issue { Id = json.Get<int>(Keys.Id), Key = json.Get<string>(Keys.Key), Self = json.Get<Uri>(Keys.Self) };
            var fields = json.Get<JsonObject>(Keys.Fields);
            if (fields != null)
            {
                issue.Summary = fields.Get<string>(FieldKeys.Summary);
                issue.Reporter = fields.Get<User>(FieldKeys.Reporter);
                issue.Assignee = fields.Get<User>(FieldKeys.Assignee);
                issue.Description = fields.Get<string>(FieldKeys.Description);
                issue.Project = fields.Get<BasicProject>(FieldKeys.Project);

                if (fields.ContainsKey(FieldKeys.TransitionsUri))
                {
                    issue.TransitionsUri = fields.Get<Uri>(FieldKeys.TransitionsUri);
                }
                else if (issue.Self != null)
                {
                    issue.TransitionsUri = issue.Self.Append("transitions");
                }

                issue.FixVersions = fields.Get<IEnumerable<JiraVersion>>(FieldKeys.FixVersions);
                issue.AffectedVersions = fields.Get<IEnumerable<JiraVersion>>(FieldKeys.AffectedVersions);
            }

            return issue;
        }

        private static class FieldKeys
        {
            public const string AffectedVersions = "versions";

            public const string Assignee = "assignee";

            public const string Description = "description";

            public const string FixVersions = "fixVersions";

            public const string Project = "project";

            public const string Reporter = "reporter";

            public const string Summary = "summary";

            public const string TransitionsUri = "transitions";
        }

        private static class Keys
        {
            public const string Fields = "fields";

            public const string Id = "id";

            public const string Key = "key";

            public const string Self = "self";
        }
    }
}
