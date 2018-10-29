using InitialCore.Utilities.Constants;
using Neo4j.Driver.V1;
using System;

namespace InitialCore.Data.Settings.Settings
{
    public class ConnectionSettings : IConnectionSettings
    {
        public Uri Uri { get; private set; }

        public IAuthToken AuthToken { get; private set; }

        public string UserName { get; private set; }

        public string Password { get; private set; }

        public ConnectionSettings(Uri uri, string userName, string password)
        {
            Uri = uri;
            UserName = userName;
            Password = password;
        }

        public static ConnectionSettings CreateBasicAuth()
        {
            return new ConnectionSettings(new Uri(SystemConstants.URI), SystemConstants.USER_NAME, SystemConstants.PASSWORD);
        }
    }
}