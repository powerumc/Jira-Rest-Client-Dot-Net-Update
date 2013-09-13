// -----------------------------------------------------------------------
// <copyright file="AddressableNamedEntity.cs" company="David Bevin">
//     Copyright (c) David Bevin.
// </copyright>
// -----------------------------------------------------------------------

using System;

namespace JIRC.Domain
{
    public class AddressableNamedEntity
    {
        public string Name { get; set; }
        public Uri Self { get; set; }
    }
}
