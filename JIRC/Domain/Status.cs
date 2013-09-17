using System;

namespace JIRC.Domain
{
    public class Status : BasicStatus
    {
        public Status(Uri self, string name, string description, Uri iconUrl)
            : base(self, name)
        {
            Description = description;
            IconUrl = iconUrl;
        }

        public string Description { get; private set; }

        public Uri IconUrl { get; private set; }
    }
}
