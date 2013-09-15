using System;

namespace JIRC.Domain
{
    public class Session
    {
        public Uri UserUri { get; set; }

        public string UserName { get; set; }

        public LoginInfo LoginInfo { get; set; }
    }
}
