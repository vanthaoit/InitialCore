using InitialCore.Data.Settings.Model;
using InitialCore.Data.Settings.Serializer;
using InitialCore.Utilities.Constants;
using Neo4j.Driver.V1;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InitialCore.Data.Settings.Settings
{
    public class Neo4JDbInitializer : INeo4JDbInitializer
    {
        private IConnectionSettings _setting;
        private IDriver _driver;

        public Neo4JDbInitializer(IConnectionSettings settings)
        {
            
            this._driver = GraphDatabase.Driver(settings.Uri, settings.AuthToken);
        }

      
        public IDriver CreateBasicAuth()
        {
           
            return _driver;
        }

        public ISession InitialSession()
        {
           
            using (ISession session = this._driver.Session())
            {
                return session;
            }
        }
    }
}