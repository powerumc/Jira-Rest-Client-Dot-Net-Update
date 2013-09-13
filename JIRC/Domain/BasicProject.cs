// -----------------------------------------------------------------------
// <copyright file="BasicProject.cs" company="David Bevin">
//     Copyright (c) David Bevin.
// </copyright>
// -----------------------------------------------------------------------

using System;

namespace JIRC.Domain
{
    public class BasicProject
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public string Name { get; set; }
        public Uri Self { get; set; }
    }
}
