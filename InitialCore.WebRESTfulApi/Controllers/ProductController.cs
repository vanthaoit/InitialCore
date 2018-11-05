using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InitialCore.Data.Entities;
using InitialCore.Infrastructure.Interfaces;
using InitialCore.Service.Interfaces;
using InitialCore.Data.ViewModels.Product;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InitialCore.WebRESTfulApi.Controllers
{
    public class ProductController : ApiController
    {
        IProductService _productService;
     
        IProductCategoryService _productCategoryService;

        public ProductController(IProductService productService, IProductCategoryService productCategoryService)
        {
            _productCategoryService = productCategoryService;
            _productService = productService;
         
        }
        // GET: api/Product/getall
        [HttpGet("getAll")]
        public IActionResult Get()
        {
            var allProducts = _productService.GetAll();
                        
            return new OkObjectResult(allProducts);
            
        }

        // GET: api/Product/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var productsById = _productService.GetById(id);
            return new OkObjectResult(productsById);
        }

        // POST: api/Product/post
        [HttpPost("post")]
        public IActionResult Post([FromBody]ProductViewModel product)
        {
            var result = _productService.Add(product);
            //try
            //{
            //    _productService.Save();
            //    return new OkObjectResult(result);
            //}
            //catch (Exception e)
            //{
            //    return new OkObjectResult(e.StackTrace);
            //}
            return new OkObjectResult(result);
          
        }

        // PUT: api/Product/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
