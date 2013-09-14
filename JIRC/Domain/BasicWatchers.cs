using System;

namespace JIRC.Domain
{
    public class BasicWatchers
    {
        public Uri Self { get; set; }

        public bool IsWatching { get; set; }

        public int Count { get; set; }
    }
}
