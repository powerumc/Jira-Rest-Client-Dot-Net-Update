// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UpdateFieldInput.cs" company="David Bevin">
//   Copyright (c) 2013 David Bevin.
// </copyright>
// // <summary>
//   https://bitbucket.org/dpbevin/jira-rest-client-dot-net
//   Licensed under the BSD 2-Clause License.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace JIRC.Domain.Input
{
    /// <summary>
    /// Handles updates to fields.
    /// </summary>
    internal class UpdateFieldInput
    {
        /// <summary>
        /// Initializes a new instance of the field updater.
        /// </summary>
        /// <param name="field">The field to update.</param>
        internal UpdateFieldInput(IssueFieldId field)
            : this(field, new List<FieldUpdateElement>())
        {
        }

        /// <summary>
        /// Initializes a new instance of the field updater.
        /// </summary>
        /// <param name="field">The field to update.</param>
        /// <param name="elements">The changes to make.</param>
        internal UpdateFieldInput(IssueFieldId field, IEnumerable<FieldUpdateElement> elements)
        {
            Field = field;
            Elements = elements.ToList();
        }

        /// <summary>
        /// Gets the field being modified.
        /// </summary>
        public IssueFieldId Field { get; private set; }

        /// <summary>
        /// Gets the elements to update.
        /// </summary>
        public IList<FieldUpdateElement> Elements { get; private set; }

        /// <summary>
        /// Adds an operation to the update field.
        /// </summary>
        /// <param name="operation">The operation to perform.</param>
        /// <param name="value">The value.</param>
        public void AddOperation(StandardOperation operation, object value)
        {
            Elements.Add(new FieldUpdateElement(operation, value));
        }
    }
}
