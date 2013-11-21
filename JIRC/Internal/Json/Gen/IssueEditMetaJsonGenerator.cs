// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IssueEditMetaJsonGenerator.cs" company="David Bevin">
//   Copyright (c) 2013 David Bevin.
// </copyright>
// // <summary>
//   https://bitbucket.org/dpbevin/jira-rest-client-dot-net
//   Licensed under the BSD 2-Clause License.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;

using JIRC.Domain;
using JIRC.Domain.Input;

using ServiceStack.Common.Extensions;
using ServiceStack.Text;

namespace JIRC.Internal.Json.Gen
{
    /// <summary>
    /// Handles generation of a request to update fields on an issue..
    /// </summary>
    internal static class IssueEditMetaJsonGenerator
    {
        /// <summary>
        /// Generates the JSON.
        /// </summary>
        /// <param name="fieldChanges">The changes to make to the issue.</param>
        /// <returns>The JSON.</returns>
        internal static JsonObject Generate(IList<UpdateFieldInput> fieldChanges)
        {
            var jsonObject = new JsonObject();
            var list = new JsonObject();

            if (fieldChanges != null)
            {
                foreach (var change in fieldChanges)
                {
                    list.Add(change.Field.ToRestString(), change.Elements.ConvertAll(a => new JsonObject { { a.Operation.ToRestString(), a.Value.ToString() } }).ToJson());
                }
            }

            jsonObject.Add("update", list.ToJson());
            return jsonObject;
        }
    }
}
