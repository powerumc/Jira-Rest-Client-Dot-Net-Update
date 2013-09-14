using System;

using JIRC.Domain;
using JIRC.Domain.Input;

namespace JIRC
{
    public interface IComponentRestClient
    {
        Component GetComponent(Uri componentUri);

        Component CreateComponent(string projectKey, ComponentInput componentInput);

        Component UpdateComponent(Uri componentUri, ComponentInput componentInput);

        void RemoveComponent(Uri componentUri);

        void RemoveComponent(Uri componentUri, Uri moveIssueToComponentUri);

        int GetComponentRelatedIssuesCount(Uri componentUri);
    }
}
