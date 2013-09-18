// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WatchersJsonParser.cs" company="David Bevin">
//   Copyright (c) David Bevin.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

using JIRC.Domain;

using ServiceStack.Text;

namespace JIRC.Internal.Json
{
    internal static class WatchersJsonParser
    {
        public static Watchers Parse(JsonObject json)
        {
            return new Watchers
            {
                IsWatching = json.Get<bool>("isWatching"),
                Self = json.Get<Uri>("self"),
                Count = json.Get<int>("watchCount"),
                Users = json.Get<IEnumerable<BasicUser>>("watchers")
            };
        }
    }
}
