// -----------------------------------------------------------------------
// <copyright file="Comment.cs" company="David Bevin">
//     Copyright (c) David Bevin.
// </copyright>
// -----------------------------------------------------------------------

using System;

namespace JIRC.Domain
{
    public class Comment
    {
        public BasicUser Author { get; set; }
        public string Body { get; set; }
        public DateTime CreationDate { get; set; }
        public int? Id { get; set; }

        public Uri Self { get; set; }

        public BasicUser UpdateAuthor { get; set; }

        public DateTime UpdateDate { get; set; }

        public static Comment Create(string body)
        {
            return new Comment { Body = body };
        }

        /*
        public static Comment CreateWithRoleLevel(string body, string roleLevel)
        {
            
        }
        */
    }
}
