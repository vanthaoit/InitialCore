using System;
using System.Collections.Generic;
using AutoMapper;
using InitialCore.Data.EF;
using InitialCore.Data.Settings;
using InitialCore.Service.AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace InitialCore.MSTest
{
    public abstract class BaseUnitTest
    {
        protected readonly ApplicationDbContext _dbContext;
        protected readonly Neo4JDbContext _neo4jContext;
        public BaseUnitTest()
        {
            // MemoryDB
            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            //optionBuilder.UseInMemoryDatabase();
            _dbContext = new ApplicationDbContext(optionBuilder.Options);


            //Setup Mapper
            Mapper.Initialize(x =>
               x.AddProfile<DomainToViewModelMappingProfile>()
           );

            //this.Setup();
        }

        protected abstract void Setup();
    }
        
}
