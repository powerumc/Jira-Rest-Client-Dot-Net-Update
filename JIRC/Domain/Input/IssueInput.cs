﻿using System.Collections.Generic;

namespace JIRC.Domain.Input
{
    public class IssueInput
    {
        public IssueInput()
            : this(new Dictionary<string, FieldInput>())
        {
        }

        internal IssueInput(IDictionary<string, FieldInput> fields)
        {
            Fields = fields;
        }

        public static IssueInput CreateWithFields(IList<FieldInput> fields)
        {
            var issue = new IssueInput();

            foreach (var f in fields)
            {
                issue.Fields.Add(f.Id, f);
            }

            return issue;
        }

        public IDictionary<string, FieldInput> Fields { get; private set; }
    }
}
