using System;

namespace JIRC.Domain.Input
{
    public class VersionInput
    {
        public string ProjectKey { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTimeOffset? ReleaseDate { get; set; }

        public bool Archived { get; set; }

        public bool Released { get; set; }
    }
}
