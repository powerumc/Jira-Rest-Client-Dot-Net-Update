using System;
using System.Globalization;

namespace JIRC.Extensions
{
    public static class RestFormatExtensions
    {
        public static string ToRestString(this DateTimeOffset dt)
        {
            return dt.ToString("o", CultureInfo.InvariantCulture);
        }
    }
}
