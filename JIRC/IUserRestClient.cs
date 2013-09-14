using System;

using JIRC.Domain;

namespace JIRC
{
    public interface IUserRestClient
    {
        User GetUser(string username);

        User GetUser(Uri userUri);
    }
}
