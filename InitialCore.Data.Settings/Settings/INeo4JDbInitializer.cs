using Neo4j.Driver.V1;
using Neo4jClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace InitialCore.Data.Settings.Settings
{
    public interface INeo4JDbInitializer
    {
        IGraphClient CreateBasicAuth();

    }
}
