namespace InitialCore.Data.Settings
{
    public class Neo4JDbContext
    {
        public static Neo4JDbContext Initial()
        {
            return new Neo4JDbContext();
        }
    }
}