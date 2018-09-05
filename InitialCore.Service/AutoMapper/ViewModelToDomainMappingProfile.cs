using AutoMapper;
using InitialCore.Application.ViewModels.Product;
using InitialCore.Data.Entities;

namespace InitialCore.Service.AutoMapper
{
	public class ViewModelToDomainMappingProfile : Profile
	{
		public ViewModelToDomainMappingProfile()
		{
			CreateMap<ProductCategoryViewModel, ProductCategory>()
				.ConstructUsing(c => new ProductCategory(c.Name, c.Description, c.ParentId, c.HomeOrder, c.Image, c.HomeFlag,
				c.SortOrder, c.Status, c.SeoPageTitle, c.SeoAlias, c.SeoKeywords, c.SeoDescription));
		}
	}
}