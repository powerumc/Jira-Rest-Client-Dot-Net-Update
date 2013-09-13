// -----------------------------------------------------------------------
// <copyright file="BasicComponent.cs" company="David Bevin">
//     Copyright (c) David Bevin.
// </copyright>
// -----------------------------------------------------------------------

namespace JIRC.Domain
{
    public class BasicComponent : AddressableNamedEntity
    {
        public string Description { get; set; }
        public int Id { get; set; }
    }
}
