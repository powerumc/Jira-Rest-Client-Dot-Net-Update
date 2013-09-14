using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using JIRC.Domain;

namespace JIRC
{
    public interface IMetadataRestClient
    {
        IssueType GetIssueType(Uri uri);

        IEnumerable<IssueType> GetIssueTypes();

        IEnumerable<IssueLinksType> GetIssueLinkTypes();

        Status GetStatus(Uri uri);

        Priority GetPriority(Uri uri);

        IEnumerable<Priority> GetPriorities();

        Resolution GetResolution(Uri uri);

        IEnumerable<Resolution> GetResolutions();

        ServerInfo GetServerInfo();

        IEnumerable<Field> GetFields();
    }
}
