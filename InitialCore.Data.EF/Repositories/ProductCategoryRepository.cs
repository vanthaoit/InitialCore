using System.Collections.Generic;
using System.Linq;
using InitialCore.Data.Entities;
using InitialCore.Data.IRepositories;

namespace InitialCore.Data.EF.Repositories
{
	public class ProductCategoryRepository : EFRepository<ProductCategory, int>, IProductCategoryRepository
	{
		private ApplicationDbContext _context;

		public ProductCategoryRepository(ApplicationDbContext context) : base(context)
		{
			_context = context;
		}

		public List<ProductCategory> GetByAlias(string alias)
		{
			return _context.ProductCategories.Where(x => x.SeoAlias == alias).ToList();
		}
	}
}