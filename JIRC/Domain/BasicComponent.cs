// -----------------------------------------------------------------------
// <copyright file="BasicComponent.cs" company="David Bevin">
//     Copyright (c) David Bevin.
// </copyright>
// -----------------------------------------------------------------------

using System;

namespace JIRC.Domain
{
    public class BasicComponent : AddressableNamedEntity
    {
        public BasicComponent(Uri self, long? id, string name, string description)
            : base(self, name)
        {
            Id = id;
            Description = description;
        }

        public long? Id { get; private set; }

        public string Description { get; private set; }
    }
}
