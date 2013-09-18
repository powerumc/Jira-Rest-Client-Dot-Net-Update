using System;
using System.Collections.Generic;

using JIRC.Domain;
using JIRC.Extensions;
using JIRC.Internal.Json;

using ServiceStack.ServiceClient.Web;
using ServiceStack.Text;

namespace JIRC.Clients
{
    internal class JiraSearchRestClient : ISearchRestClient
    {
        private const string FilterUriPrefix = "filter";

        private const string SearchUriPrefix = "search";

        private const string FavouruteUriPostfix = "favourite";

        private const int MaxJqlLengthForGet = 500;

        private readonly JsonServiceClient client;

        private readonly Uri searchUri;

        public JiraSearchRestClient(JsonServiceClient client)
        {
            this.client = client;

            searchUri = new Uri(client.BaseUri).Append(SearchUriPrefix);
        }

        public SearchResult SearchJql(string jql)
        {
            return SearchJql(jql, null, null);
        }

        public SearchResult SearchJql(string jql, int? maxResults, int? startAt, params string[] fields)
        {
            var qb = new UriBuilder(searchUri);
            qb.AppendQuery("jql", jql);

            if (maxResults != null)
            {
                qb.AppendQuery("maxResults", maxResults.ToString());
            }

            if (startAt != null)
            {
                qb.AppendQuery("startAt", startAt.ToString());
            }

            if (fields != null)
            {
                qb.AppendQuery("fields", fields.Join(","));
            }

            var query = qb.Uri.ToString();

            return query.Length > MaxJqlLengthForGet ? client.Put<SearchResult>(query, string.Empty) : client.Get<SearchResult>(query);
        }

        public IEnumerable<Filter> GetFavouriteFilters()
        {
            return client.Get<IEnumerable<Filter>>("/{0}/{1}".Fmt(FilterUriPrefix, FavouruteUriPostfix));
        }

        public Filter GetFilter(Uri filterUri)
        {
            return client.Get<Filter>(filterUri.ToString());
        }

        public Filter GetFilter(int id)
        {
            return client.Get<Filter>("/{0}/{1}".Fmt(FilterUriPrefix, id));
        }
    }
}
