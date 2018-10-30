using System;
using System.Collections.Generic;
using System.Text;
using InitialCore.Data.EF.Repositories;
using InitialCore.Data.Entities;
using InitialCore.Infrastructure.Interfaces;
using InitialCore.Service.Implementation;
using InitialCore.Service.Interfaces;
using InitialCore.Data.ViewModels.Product;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace InitialCore.MSTest.Service
{
    [TestClass]
    public class ProductCategoryServiceTest:BaseUnitTest
    {
        private Mock<IRepository<ProductCategory, int>> _mockProduct;
        private Mock<IUnitOfWork> _mockUnitOfWork;
        private IProductCategoryService _productCategoryService;
        private ProductCategoryViewModel _productCategoryVm;
        private ProductCategory _productCategory;

        [TestInitialize]
        public void Initialize()
        {
            _mockProduct = new Mock<IRepository<ProductCategory, int>>();
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _productCategoryService = new ProductCategoryService(_mockProduct.Object, _mockUnitOfWork.Object);
            
            _productCategoryVm = new ProductCategoryViewModel()
            {
                //Id = 4,
                Name = "Samsung",
                Description = "samsung",
                ParentId = 0,
                SortOrder = 0,
                Status = 0,
                DateCreated = DateTime.Now,
                DateModified = DateTime.Now,
                HomeFlag = true,
                HomeOrder = 1

            };
            _productCategory = new ProductCategory()
            {
                //Id = 4,
                Name = "Samsung",
                Description = "samsung",
                ParentId = 0,
                SortOrder = 0,
                Status = 0,
                DateCreated = DateTime.Now,
                DateModified = DateTime.Now,
                HomeFlag = true,
                HomeOrder = 1
            };

        }
        [TestMethod]
        public void Product_Category_Service_Create()
        {
            _mockProduct
                .Setup(x => x.Add(_productCategory))
                .Returns((ProductCategory p) => {
                    p.Description = "create product";
                    return p;
                });
            var result = _productCategoryService.GetAll();
            //var result = _productCategoryService.Add(_productCategoryVm);
            //_productCategoryService.Save();
            Assert.IsNotNull(result);
            //Assert.AreEqual(4, result.Id);
        }

        protected override void Setup()
        {
            throw new NotImplementedException();
        }
    }
}
