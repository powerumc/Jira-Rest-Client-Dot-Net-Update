// -----------------------------------------------------------------------
// <copyright file="User.cs" company="David Bevin">
//     Copyright (c) David Bevin.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace JIRC.Domain
{
    public class User : BasicUser
    {
        public static string Size16 = "16x16";

        public static string Size48 = "48x48";

        public Dictionary<string, Uri> AvatarUrls { get; set; }

        public string EmailAddress { get; set; }

        public Uri SmallAvatarUri
        {
            get
            {
                if (AvatarUrls != null)
                {
                    Uri uri = AvatarUrls[Size16];
                    if (uri != default(Uri))
                    {
                        return uri;
                    }
                }

                return null;
            }
        }
    }
}
