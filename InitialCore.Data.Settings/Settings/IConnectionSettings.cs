using System;
using System.Collections.Generic;
using System.Text;
using Neo4j.Driver.V1;

namespace InitialCore.Data.Settings.Settings
{
    public interface IConnectionSettings
    {

        string Uri { get; }

        IAuthToken AuthToken { get; }

    }
}
