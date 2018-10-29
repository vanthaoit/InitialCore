using System;
using System.Collections.Generic;
using System.Text;
using InitialCore.Utilities.Constants;
using Neo4j.Driver.V1;

namespace InitialCore.Data.Settings.Settings
{
    public class ConnectionSettings:IConnectionSettings
    {

        public string Uri { get; private set; }

        public IAuthToken AuthToken { get; private set; }

        public ConnectionSettings(string uri, IAuthToken authToken)
        {
            Uri = uri;
            AuthToken = authToken;
        }

        public static ConnectionSettings CreateBasicAuth()
        {
            return new ConnectionSettings(SystemConstants.URI, AuthTokens.Basic(SystemConstants.USER_NAME, SystemConstants.PASSWORD));
        }

    }
}
