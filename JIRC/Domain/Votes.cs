using System.Collections.Generic;

namespace JIRC.Domain
{
    public class Votes : BasicVotes
    {
        public IEnumerable<BasicUser> Voters { get; set; }
    }
}
