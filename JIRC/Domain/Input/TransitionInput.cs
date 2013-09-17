// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TransitionInput.cs" company="David Bevin">
//   Copyright (c) David Bevin.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;

namespace JIRC.Domain.Input
{
    public class TransitionInput
    {
        public int Id { get; set; }

        public Comment Comment { get; set; }

        public IEnumerable<FieldInput> Fields { get; set; }
    }
}
