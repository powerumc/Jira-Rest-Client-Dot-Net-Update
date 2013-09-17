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
        public BasicProject(Uri self, string key, string name)
        {
            Self = self;
            Key = key;
            Name = name;
        }

        public string Key { get; private set; }
        public string Name { get; private set; }
        public Uri Self { get; private set; }
    }
}
