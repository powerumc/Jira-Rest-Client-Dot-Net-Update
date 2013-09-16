﻿
using JIRC.Domain;
using JIRC.Domain.Input;

using ServiceStack.Text;

namespace JIRC.Internal.Json.Gen
{
    internal static class LinkIssuesInputJsonGenerator
    {
        internal static JsonObject Generate(LinkIssuesInput linkIssuesInput, ServerInfo serverInfo)
        {
            var json = new JsonObject();

            if (serverInfo.BuildNumber >= ServerVersionConstants.BuildNumberJira5)
            {
                var jsonType = new JsonObject { { "name", linkIssuesInput.LinkType } };
                var jsonInward = new JsonObject { { "key", linkIssuesInput.FromIssueKey } };
                var jsonOutward = new JsonObject { { "key", linkIssuesInput.ToIssueKey } };

                json.Add("type", jsonType.ToString());
                json.Add("inwardIssue", jsonInward.ToString());
                json.Add("outwardIssue", jsonOutward.ToString());
            }
            else
            {
                json.Add("linkType", linkIssuesInput.LinkType);
                json.Add("fromIssueKey", linkIssuesInput.FromIssueKey);
                json.Add("toIssueKey", linkIssuesInput.ToIssueKey);
            }

            if (linkIssuesInput.Comment != null)
            {
                json.Add("comment", CommentJsonGenerator.Generate(linkIssuesInput.Comment, serverInfo).ToString());
            }

            return json;
        }
    }
}