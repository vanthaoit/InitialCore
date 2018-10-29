using Neo4j.Driver.V1;
using System;
using System.Collections.Generic;
using System.Text;

namespace InitialCore.Data.Settings.Settings
{
    public interface INeo4JDbInitializer
    {
        IDriver CreateBasicAuth();

        ISession InitialSession();
    }
}
