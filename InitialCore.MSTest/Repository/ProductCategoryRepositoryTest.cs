using System;
using System.Collections.Generic;
using System.Text;
using InitialCore.Data.EF;
using InitialCore.Data.EF.Repositories;
using InitialCore.Data.Entities;
using InitialCore.Infrastructure.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InitialCore.MSTest.Repository
{
    [TestClass]
    public class ProductCategoryRepositoryTest:BaseUnitTest
    {
        
        private IUnitOfWork unitOfWork;
        private IRepository<ProductCategory,int> productCategoryRepository;
       

        [TestInitialize]
        public void Initialize()
        {
            
            unitOfWork = new EFUnitOfWork(_dbContext);
            productCategoryRepository = new ProductCategoryRepository(_dbContext);

        }
        [TestMethod]
        public void Product_Category_Repository_Create()
        {
            ProductCategory productCategory = new ProductCategory();
            productCategory.Name = "Samsung";
            productCategory.Description = "samsung";
            productCategory.ParentId = 0;
            productCategory.SortOrder = 0;
            productCategory.Status = 0;
            productCategory.DateCreated = DateTime.Now;
            productCategory.DateModified = DateTime.Now;

            var result = productCategoryRepository.Add(productCategory);
            unitOfWork.Commit();
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Id);
        }

        protected override void Setup()
        {
            throw new NotImplementedException();
        }
    }
}
