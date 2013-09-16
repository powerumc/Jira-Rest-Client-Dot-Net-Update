using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using JIRC.Domain;

using ServiceStack.Text;

namespace JIRC.Internal.Json.Gen
{
    internal static class CommentJsonGenerator
    {
        internal static JsonObject Generate(Comment comment, ServerInfo serverInfo)
        {
            var json = new JsonObject();

            if (comment.Body != null)
            {
                json.Add("body", comment.Body);
            }

            if (comment.Visibility != null)
            {
                if (serverInfo.BuildNumber >= ServerVersionConstants.BuildNumberJira43)
                {
                    var visibilityJson = new JsonObject();
                    var commentVisibilityType = comment.Visibility.Type == Visibility.VisibilityType.Group ? "group" : "role";

                    if (serverInfo.BuildNumber < ServerVersionConstants.BuildNumberJira5)
                    {
                        commentVisibilityType = commentVisibilityType.ToUpper();
                    }

                    visibilityJson.Add("type", commentVisibilityType);
                    visibilityJson.Add("value", comment.Visibility.Value);
                    json.Add("visibility", visibilityJson.ToString());
                }
                else
                {
                    json.Add(comment.Visibility.Type == Visibility.VisibilityType.Role ? "role" : "group", comment.Visibility.Value);
                }
            }

            return json;
        }
    }
}
