using AutoMapper;
using AutoMapper.QueryableExtensions;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using InitialCore.Service.Interfaces;
using InitialCore.Service.ViewModels.Common;
using InitialCore.Data.Entities;
using InitialCore.Data.Enums;
using InitialCore.Infrastructure.Interfaces;
using InitialCore.Utilities.Constants;
using InitialCore.Utilities.Dtos;
using InitialCore.Utilities.Helpers;
using InitialCore.Data.ViewModels.Product;

namespace InitialCore.Service.Implementation
{
    public class ProductService : IProductService
    {
        private IRepository<ProductViewModel, int> _productRepository;
       

        private IUnitOfWork _unitOfWork;

        public ProductService(IRepository<ProductViewModel, int> productRepository, IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
        
          
            _unitOfWork = unitOfWork;
        }

        public ProductViewModel Add(ProductViewModel productVm)
        {
            var response = _productRepository.Add(productVm);
            return productVm;
        }

      

        public void Delete(int id)
        {
            _productRepository.Remove(id);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public List<ProductViewModel> GetAll()
        {
            //return _productRepository.FindAll(x => x.ProductCategoryViewModel).ProjectTo<ProductViewModel>().ToList();
            var response =  _productRepository.FindAll().ToList();
            return response;
        }

        public void Update(ProductViewModel product)
        {
            throw new NotImplementedException();
        }
    }
}