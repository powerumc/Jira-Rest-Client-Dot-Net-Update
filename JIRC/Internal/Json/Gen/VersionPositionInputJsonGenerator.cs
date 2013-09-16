using System;
using System.Collections.Generic;
using System.Linq;
using JIRC.Domain.Input;

using ServiceStack.Text;

namespace JIRC.Internal.Json.Gen
{
    internal static class VersionPositionInputJsonGenerator
    {
        internal static JsonObject Generate(VersionPosition versionPosition)
        {
            string posValue;

            switch (versionPosition)
            {
                case VersionPosition.First:
                    posValue = "First";
                    break;

                case VersionPosition.Last:
                    posValue = "Last";
                    break;

                case VersionPosition.Earlier:
                    posValue = "Earlier";
                    break;

                case VersionPosition.Later:
                    posValue = "Later";
                    break;

                default:
                    throw new ArgumentException("Invalid version position value", "versionPosition");
            }

            return new JsonObject { { "position", posValue } };
        }
    }
}
