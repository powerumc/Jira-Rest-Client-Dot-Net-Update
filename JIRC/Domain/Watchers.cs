// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Watchers.cs" company="David Bevin">
//   Copyright (c) David Bevin.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;

namespace JIRC.Domain
{
    public class Watchers : BasicWatchers
    {
        public IEnumerable<BasicUser> Users { get; set; }
    }
}
