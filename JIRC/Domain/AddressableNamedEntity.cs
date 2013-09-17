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
        protected AddressableNamedEntity(Uri self, string name)
        {
            Self = self;
            Name = name;
        }

        public string Name { get; protected set; }
        public Uri Self { get; protected set; }
    }
}
