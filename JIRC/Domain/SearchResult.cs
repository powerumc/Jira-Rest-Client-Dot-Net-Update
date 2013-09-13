using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JIRC.Domain
{
    public class SearchResult
    {
        public int StartIndex { get; set; }

        public int MaxResults { get; set; }

        public int Total { get; set; }

        public IEnumerable<Issue> Issues { get; set; }
    }
}
