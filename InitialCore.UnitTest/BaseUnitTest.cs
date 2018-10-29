using System;
using System.Collections.Generic;
using AutoMapper;
using InitialCore.Data.EF;
using InitialCore.Service.AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace InitialCore.UnitTest
{
    public abstract class BaseUnitTest
    {
        protected readonly ApplicationDbContext _dbContext;
        public BaseUnitTest()
        {
            // MemoryDB
            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionBuilder.UseInMemoryDatabase();
            _dbContext = new ApplicationDbContext(optionBuilder.Options);


            //Setup Mapper
            Mapper.Initialize(x =>
               x.AddProfile<DomainToViewModelMappingProfile>()
           );

            this.Setup();
        }

        protected abstract void Setup();
    }
        
}
