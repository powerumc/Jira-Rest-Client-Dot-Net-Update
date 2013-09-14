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
        void AddComment(BasicIssue issueUri, Comment comment);

        void AddComment(Uri commentsUri, Comment comment);

        Issue GetIssue(string key);

        Watchers GetWatchers(Uri watchersUri);

        Votes GetVotes(Uri votesUri);

        IEnumerable<Transition> GetTransitions(Uri transitionsUri);

        IEnumerable<Transition> GetTransitions(Issue issue);

        void Transition(Uri transitionsUri, TransitionInput transitionInput);

        void Transition(Issue issue, TransitionInput transitionInput);
    }
}
