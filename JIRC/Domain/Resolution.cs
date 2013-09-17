using System;

namespace JIRC.Domain
{
    public class Resolution : BasicResolution
    {
        public Resolution(Uri self, string name, string descritpion)
            : base(self, name)
        {
            Description = descritpion;
        }

        public string Description { get; private set; }
    }
}
