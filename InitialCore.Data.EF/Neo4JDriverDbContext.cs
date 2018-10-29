using System;
using System.Linq;
using InitialCore.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Neo4j.Driver.V1;

namespace InitialCore.Data.EF
{
    public class Neo4JDriverDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {
        private readonly IDriver _driver;

        public Neo4JDriverDbContext()
        {

        }
        public Neo4JDriverDbContext(DbContextOptions options): base(options)
        {
          
            //_driver = GraphDatabase.Driver("bolt://localhost:7687", AuthTokens.Basic("neo4j", "khongcomatkhau"));
        }

        public Neo4JDriverDbContext(string uri, string user, string password)
        {
            _driver = GraphDatabase.Driver(uri, AuthTokens.Basic(user, password));
        }
        //public executeDbContext(string uri, string user, string password)
        //{

        //}

        public void PrintGreeting(string message)
        {
            using (var session = _driver.Session())
            {
              
            }
        }

        //public override void dispose()
        //{
        //    _driver?.dispose();
        //}

        public static void Main()
        {
            using (var greeter = new Neo4JDriverDbContext("bolt://localhost:7687", "neo4j", "khongcomatkhau"))
            {
                greeter.PrintGreeting("hello, world");
            }
        }
    }
}