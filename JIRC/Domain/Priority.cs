using System;

namespace JIRC.Domain
{
    public class Priority : BasicPriority
    {
        public Priority(Uri self, long? id, string name, string statusColor, string description, Uri iconUrl)
            : base(self, id, name)
        {
            StatusColor = statusColor;
            Description = description;
            IconUrl = iconUrl;
        }

        // TODO: Convert to a colour object?
        public string StatusColor { get; private set; }

        public string Description { get; private set; }

        public Uri IconUrl { get; private set; }
    }
}
