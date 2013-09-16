using System;
using System.Collections.Generic;

using JIRC.Domain;

namespace JIRC
{
    public interface ISearchRestClient
    {
        SearchResult SearchJql(string jql);

        SearchResult SearchJql(string jql, int? maxResults, int? startAt, params string[] fields);

        IEnumerable<Filter> GetFavouriteFilters();

        Filter GetFilter(Uri filterUri);

        Filter GetFilter(int id);
    }
}
