// -----------------------------------------------------------------------
// <copyright file="BasicIssue.cs" company="David Bevin">
//     Copyright (c) David Bevin.
// </copyright>
// -----------------------------------------------------------------------

using System;

namespace JIRC.Domain
{
    public class BasicIssue
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public Uri Self { get; set; }
    }
}
