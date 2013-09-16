﻿// -----------------------------------------------------------------------
// <copyright file="BasicProject.cs" company="David Bevin">
//     Copyright (c) David Bevin.
// </copyright>
// -----------------------------------------------------------------------

using System;

namespace JIRC.Domain
{
    public class BasicProject
    {
        public BasicProject()
        {
        }

        protected BasicProject(Uri self, string key, string name)
        {
            Self = self;
            Key = key;
            Name = name;
        }

        public int? Id { get; set; }
        public string Key { get; set; }
        public string Name { get; set; }
        public Uri Self { get; set; }
    }
}
