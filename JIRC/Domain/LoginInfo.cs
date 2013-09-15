using System;

namespace JIRC.Domain
{
    public class LoginInfo
    {
        public int FailedLoginCount { get; set; }

        public int LoginCount { get; set; }

        public DateTimeOffset? LastFailedLoginDate { get; set; }

        public DateTimeOffset? PreviousLoginDate { get; set; }
    }
}
