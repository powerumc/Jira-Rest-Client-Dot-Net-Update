using System;

using JIRC.Domain;
using JIRC.Domain.Input;

namespace JIRC
{
    public interface IVersionRestClient
    {
        JiraVersion GetVersion(Uri versionUri);

        JiraVersion CreateVersion(VersionInput versionInput);

        JiraVersion UpdateVersion(Uri versionUri, VersionInput versionInput);

        void RemoveVersion(Uri versionUri);

        void RemoveVersion(Uri versionUri, Uri moveFixIssuesToVersionUri, Uri moveAffectedIssuesToVersionUri);

        VersionRelatedIssuesCount GetVersionRelatedIssuesCount(Uri versionUri);

        int GetNumUnresolvedIssues(Uri versionUri);

        JiraVersion MoveVersionAfter(Uri versionUri, Uri afterVersionUri);

        JiraVersion MoveVersion(Uri versionUri, VersionPosition versionPosition);
    }
}
