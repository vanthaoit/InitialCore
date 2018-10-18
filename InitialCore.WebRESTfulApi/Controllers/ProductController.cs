using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InitialCore.Infrastructure.Interfaces;
using InitialCore.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InitialCore.WebRESTfulApi.Controllers
{
    public class ProductController : ApiController
    {
        IProductService _productService;
        IKASService _kasService;
        IProductCategoryService _productCategoryService;

        public ProductController(IKASService kasService,IProductCategoryService productCategoryService)
        {
            // _productService = productService;
            _productCategoryService = productCategoryService;
            _kasService = kasService;
        }
        // GET: api/Product
        [HttpGet]
        public IActionResult Get()
        {
            var abc = _productCategoryService.GetAll();
            //var kas = _kasService.GetKAS();
            return new OkObjectResult(abc);
            
        }

        // GET: api/Product/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Product
        [HttpPost]
        public void Post([FromBody] string value)
        {
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
