// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SearchResult.cs" company="David Bevin">
//   Copyright (c) David Bevin.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;

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
