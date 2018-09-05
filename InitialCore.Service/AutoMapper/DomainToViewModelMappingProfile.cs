using AutoMapper;
using InitialCore.Application.ViewModels.Product;
using InitialCore.Data.Entities;

namespace InitialCore.Service.AutoMapper
{
	public class DomainToViewModelMappingProfile : Profile
	{
		public DomainToViewModelMappingProfile()
		{
			CreateMap<ProductCategory, ProductCategoryViewModel>();
		}
	}
}