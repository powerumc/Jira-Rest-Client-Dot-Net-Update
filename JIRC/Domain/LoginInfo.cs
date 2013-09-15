using System;

namespace JIRC.Domain
{
    public class LoginInfo
    {
        public int FailedLoginCount { get; set; }

        public int LoginCount { get; set; }

        public DateTime? LastFailedLoginDate { get; set; }

        public DateTime? PreviousLoginDate { get; set; }
    }
}
