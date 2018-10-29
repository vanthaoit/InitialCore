using InitialCore.Data.Entities;
using InitialCore.Service.Interfaces;
using InitialCore.Utilities.Constants;
using Microsoft.AspNetCore.Mvc;
using Neo4j.Driver.V1;
using Neo4jClient;

namespace InitialCore.WebRESTfulApi.Controllers
{
    public class ProductCategoryController : ApiController
    {
        IProductCategoryService _productCategoryService;
        public ProductCategoryController(IProductCategoryService productCategoryService)
        {
            _productCategoryService = productCategoryService;
        }

        // api/productCategory
        [HttpGet("getAll")]
        public IActionResult Get()
        {

            //GraphClient.Cypher
            //            .Match("(user:User)")
            //            .Where((ProductCategory user) => user.Id == 1234)
            //            .Return(user => user.As<ProductCategory>())
            //            .Results;
                        
            var allProductCategories = _productCategoryService.GetAll();
            return new OkObjectResult(allProductCategories);

        }
    }
}