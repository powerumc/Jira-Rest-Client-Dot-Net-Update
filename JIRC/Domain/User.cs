// -----------------------------------------------------------------------
// <copyright file="User.cs" company="David Bevin">
//     Copyright (c) David Bevin.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;

namespace JIRC.Domain
{
    public class User : BasicUser
    {
        public static string AvatarSizeExtraSmall = "16x16";

        public static string AvatarSizeSmall = "24x24";

        public static string AvatarSizeMedium = "32x32";

        public static string AvatarSizeStandard = "48x48";

        public User(Uri self, string name, string displayName, string emailAddress, IEnumerable<string> groups, IDictionary<string, Uri> avatarUris, bool active, string timezone)
            : base(self, name, displayName)
        {
            if (avatarUris == null)
            {
                throw new ArgumentNullException("avatarUris");
            }

            if (!avatarUris.ContainsKey(AvatarSizeStandard))
            {
                throw new ArgumentException("At least one avatar Url is expected - for 48x48", "avatarUris");
            }

            Timezone = timezone;
            Active = active;
            EmailAddress = emailAddress;
            Groups = groups;
            AvatarUri = avatarUris.Where(a => a.Key == AvatarSizeStandard).Select(a => a.Value).FirstOrDefault();
            MediumAvatarUri = avatarUris.Where(a => a.Key == AvatarSizeMedium).Select(a => a.Value).FirstOrDefault();
            SmallAvatarUri = avatarUris.Where(a => a.Key == AvatarSizeSmall).Select(a => a.Value).FirstOrDefault();
            ExtraSmallAvatarUri = avatarUris.Where(a => a.Key == AvatarSizeExtraSmall).Select(a => a.Value).FirstOrDefault();
        }

        internal User(BasicUser basic, string emaiAddress, IEnumerable<string> groups, IDictionary<string, Uri> avatarUris, bool active, string timezone)
            : this(basic.Self, basic.Name, basic.DisplayName, emaiAddress, groups, avatarUris, active, timezone)
        {
        }

        public string Timezone { get; private set; }

        public bool Active { get; private set; }

        public string EmailAddress { get; private set; }

        public IEnumerable<string> Groups { get; private set; }

        public Uri AvatarUri { get; private set; }

        public Uri MediumAvatarUri { get; private set; }

        public Uri SmallAvatarUri { get; private set; }

        public Uri ExtraSmallAvatarUri { get; private set; }
    }
}
