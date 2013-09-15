using JIRC.Domain;

namespace JIRC
{
    public interface ISessionRestClient
    {
        Session GetCurrentSession();
    }
}
