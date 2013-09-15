using System;

namespace JIRC.Domain
{
    public class ServerInfo
    {
        public Uri BaseUrl { get; set; }

        public string Version { get; set; }

        public int BuildNumber { get; set; }

        public DateTimeOffset BuildDate { get; set; }

        public DateTimeOffset? ServerTime { get; set; }

        public string ScmInfo { get; set; }

        public string ServerTitle { get; set; }
    }
}
