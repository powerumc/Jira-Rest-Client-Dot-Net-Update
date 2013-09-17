using System;

namespace JIRC.Domain
{
    public class BasicPriority : AddressableNamedEntity
    {
        public BasicPriority(Uri self, long? id, string name)
            : base(self, name)
        {
            Id = id;
        }

        public long? Id { get; private set; }
    }
}
