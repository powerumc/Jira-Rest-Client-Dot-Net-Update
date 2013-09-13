// -----------------------------------------------------------------------
// <copyright file="IIssueRestClient.cs" company="David Bevin">
//     Copyright (c) David Bevin.
// </copyright>
// -----------------------------------------------------------------------

using System;

using JIRC.Domain;

namespace JIRC
{
    public interface IIssueRestClient
    {
        void AddComment(BasicIssue issueUri, Comment comment);

        void AddComment(Uri commentsUri, Comment comment);

        Issue GetIssue(string key);
    }
}
