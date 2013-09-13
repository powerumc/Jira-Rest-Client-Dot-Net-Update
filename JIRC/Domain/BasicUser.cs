// -----------------------------------------------------------------------
// <copyright file="BasicUser.cs" company="David Bevin">
//     Copyright (c) David Bevin.
// </copyright>
// -----------------------------------------------------------------------

namespace JIRC.Domain
{
    public class BasicUser : AddressableNamedEntity
    {
        public string DisplayName { get; set; }
    }
}
