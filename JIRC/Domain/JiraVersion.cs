// -----------------------------------------------------------------------
// <copyright file="JiraVersion.cs" company="David Bevin">
//     Copyright (c) David Bevin.
// </copyright>
// -----------------------------------------------------------------------

using System;

namespace JIRC.Domain
{
    public class JiraVersion
    {
        public bool Archived { get; set; }
        public string Description { get; set; }
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTimeOffset? ReleaseDate { get; set; }
        public bool Released { get; set; }
        public Uri Self { get; set; }
    }
}
