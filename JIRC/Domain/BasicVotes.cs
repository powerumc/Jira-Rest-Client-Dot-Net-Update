using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JIRC.Domain
{
    public class BasicVotes
    {
        public Uri Self { get; set; }

        public int Votes { get; set; }

        public bool HasVoted { get; set; }
    }
}
