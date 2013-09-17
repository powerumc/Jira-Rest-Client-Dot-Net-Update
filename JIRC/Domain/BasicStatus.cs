using System;

namespace JIRC.Domain
{
    public class BasicStatus : AddressableNamedEntity
    {
        public BasicStatus(Uri self, string name)
            : base(self, name)
        {
        }
    }
}
