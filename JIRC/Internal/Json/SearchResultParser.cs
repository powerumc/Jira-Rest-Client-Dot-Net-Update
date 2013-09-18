// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SearchResultParser.cs" company="David Bevin">
//   Copyright (c) David Bevin.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using JIRC.Domain;

using ServiceStack.Text;

namespace JIRC.Internal.Json
{
    internal class SearchResultParser
    {
        public SearchResult Parse(JsonObject json)
        {
            var result = new SearchResult
            {
                Total = json.Get<int>("total"),
                MaxResults = json.Get<int>("maxResults"),
                StartIndex = json.Get<int>("startAt"),
                Issues = json.ArrayObjects("issues").ConvertAll(IssueJsonParser.Parse)
            };

            return result;
        }
    }
}
