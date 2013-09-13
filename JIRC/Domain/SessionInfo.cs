// -----------------------------------------------------------------------
// <copyright file="SessionInfo.cs" company="David Bevin">
//     Copyright (c) David Bevin.
// </copyright>
// -----------------------------------------------------------------------

namespace JIRC.Domain
{
    public class SessionInfo
    {
        public SessionToken Session { get; set; }

        public class SessionToken
        {
            public string Name { get; set; }
            public string Value { get; set; }
        }
    }
}
