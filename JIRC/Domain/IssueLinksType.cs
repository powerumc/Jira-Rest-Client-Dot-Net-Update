using System;

namespace JIRC.Domain
{
    public class IssueLinksType : AddressableNamedEntity
    {
        public IssueLinksType(Uri self, string id, string name, string inward, string outward)
            : base(self, name)
        {
            Id = id;
            Inward = inward;
            Outward = outward;
        }

        public string Id { get; private set; }

        public string Inward { get; private set; }

        public string Outward { get; private set; }
    }
}
