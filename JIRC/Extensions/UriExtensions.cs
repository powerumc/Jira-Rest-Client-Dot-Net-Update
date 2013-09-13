// -----------------------------------------------------------------------
// <copyright file="UriExtensions.cs" company="David Bevin">
//     Copyright (c) David Bevin.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.IO;

namespace JIRC.Extensions
{
    internal static class UriExtensions
    {
        internal static Uri Append(this Uri uri, string param)
        {
            var relative = new Uri(param, UriKind.Relative);
            return new Uri(Path.Combine(uri.ToString(), relative.ToString()));
        }
    }
}
