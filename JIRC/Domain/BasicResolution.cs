using System;

namespace JIRC.Domain
{
    public class BasicResolution : AddressableNamedEntity
    {
        public BasicResolution(Uri self, string name)
            : base(self, name)
        {
        }
    }
}
