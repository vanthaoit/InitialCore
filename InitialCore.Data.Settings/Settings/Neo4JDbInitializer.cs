using Neo4jClient;
using System;

namespace InitialCore.Data.Settings.Settings
{
    public class Neo4JDbInitializer : INeo4JDbInitializer
    {
        private IConnectionSettings _setting;
        private IGraphClient _driver;

        public Neo4JDbInitializer(IConnectionSettings settings)
        {
            //_setting = settings;
            //this._driver = GraphDatabase.Driver(settings.Uri, settings.AuthToken);
            this._driver = new GraphClient(settings.Uri, settings.UserName, settings.Password);
        }

        public IGraphClient CreateBasicAuth()
        {
            return _driver;
        }

    }
}