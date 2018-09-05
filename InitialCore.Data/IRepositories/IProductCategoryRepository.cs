using System.Collections.Generic;
using InitialCore.Data.Entities;
using InitialCore.Infrastructure.Interfaces;

namespace InitialCore.Data.IRepositories
{
	public interface IProductCategoryRepository : IRepository<ProductCategory, int>
	{
		List<ProductCategory> GetByAlias(string alias);
	}
}