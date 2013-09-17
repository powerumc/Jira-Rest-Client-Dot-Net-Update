using System;

namespace JIRC.Domain
{
    public class SecurityLevel : AddressableNamedEntity
    {
        public SecurityLevel(Uri self, long id, string name, string description)
            : base(self, name)
        {
            Id = id;
            Description = description;
        }

        public long Id { get; private set; }

        public string Description { get; private set; }
    }
}
