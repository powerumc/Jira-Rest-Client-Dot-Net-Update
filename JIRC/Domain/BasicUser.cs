// -----------------------------------------------------------------------
// <copyright file="BasicUser.cs" company="David Bevin">
//     Copyright (c) David Bevin.
// </copyright>
// -----------------------------------------------------------------------

using System;

namespace JIRC.Domain
{
    public class BasicUser : AddressableNamedEntity
    {
        public BasicUser(Uri self, string name, string displayName)
            : base(self, name)
        {
            DisplayName = displayName;
        }

        public string DisplayName { get; private set; }
    }
}
