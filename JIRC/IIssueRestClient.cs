// -----------------------------------------------------------------------
// <copyright file="IIssueRestClient.cs" company="David Bevin">
//     Copyright (c) David Bevin.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;

using JIRC.Domain;
using JIRC.Domain.Input;

namespace JIRC
{
    public interface IIssueRestClient
    {
        BasicIssue CreateIssue(IssueInput issue);

        IEnumerable<CimProject> GetCreateIssueMetadata();

        IEnumerable<CimProject> GetCreateIssueMetadata(GetCreateIssueMetadataOptions options);

        BulkOperationResult<BasicIssue> CreateIssues(IList<IssueInput> issues);

        Issue GetIssue(string key);

        void DeleteIssue(string issueKey, bool deleteSubtasks);

        Watchers GetWatchers(Uri watchersUri);

        Votes GetVotes(Uri votesUri);

        IEnumerable<Transition> GetTransitions(Uri transitionsUri);

        IEnumerable<Transition> GetTransitions(Issue issue);

        void Transition(Uri transitionsUri, TransitionInput transitionInput);

        void Transition(Issue issue, TransitionInput transitionInput);

        void Vote(Uri votesUri);

        void Unvote(Uri votesUri);

        void Watch(Uri watchersUri);

        void Unwatch(Uri watchersUri);

        void AddWatcher(Uri watchersUri, string username);

        void RemoveWatcher(Uri watchersUri, string username);

        void LinkIssue(LinkIssuesInput linkIssuesInput);

//        void AddAttachment(Uri attachmentsUri, Stream in, string filename);

//        void AddAttachments(Uri attachmentsUri, params AttachmentInput[] attachments);

//        void AddAttachments(Uri attachmentsUri, params File[] files);

        void AddComment(BasicIssue issueUri, Comment comment);

        void AddComment(Uri commentsUri, Comment comment);

//        Stream GetAttachment(Uri attachmentUri);

        void AddWorklog(Uri worklogUri, WorklogInput worklogInput);
    }
}
