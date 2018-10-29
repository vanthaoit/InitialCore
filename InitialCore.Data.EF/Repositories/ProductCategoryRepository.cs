using System.Collections.Generic;
using System.Linq;
using InitialCore.Data.Entities;
using InitialCore.Data.IRepositories;
using InitialCore.Data.Settings;

namespace InitialCore.Data.EF.Repositories
{
	public class ProductCategoryRepository : EFRepository<ProductCategory, int>, IProductCategoryRepository
	{
		private ApplicationDbContext _context;

        private Neo4JDbContext _neo4jDbContext;


        public ProductCategoryRepository(ApplicationDbContext context) :base(context)
		{
			_context = context;
            //_neo4jDbContext = neo4jDbContext;
		}

		public List<ProductCategory> GetByAlias(string alias)
		{
			return _context.ProductCategories.Where(x => x.SeoAlias == alias).ToList();
		}
	}
}