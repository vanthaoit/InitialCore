using AutoMapper;
using AutoMapper.QueryableExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InitialCore.Service.Interfaces;
using InitialCore.Service.ViewModels.Blog;
using InitialCore.Service.ViewModels.Common;
using InitialCore.Data.Entities;
using InitialCore.Infrastructure.Interfaces;
using InitialCore.Utilities.Constants;
using InitialCore.Utilities.Dtos;
using InitialCore.Utilities.Helpers;

namespace InitialCore.Service.Implementation
{
    public class CommonService : ICommonService
    {
        IRepository<Footer, string> _footerRepository;
        IRepository<SystemConfig, string> _systemConfigRepository;
        IUnitOfWork _unitOfWork;
        IRepository<Slide, int> _slideRepository;
        public CommonService(IRepository<Footer, string> footerRepository,
            IRepository<SystemConfig, string> systemConfigRepository,
            IUnitOfWork unitOfWork,
            IRepository<Slide, int> slideRepository)
        {
            _footerRepository = footerRepository;
            _unitOfWork = unitOfWork;
            _systemConfigRepository = systemConfigRepository;
            _slideRepository = slideRepository;
        }

        public FooterViewModel GetFooter()
        {
            return Mapper.Map<Footer, FooterViewModel>(_footerRepository.FindSingle(x => x.Id ==
            CommonConstants.DefaultFooterId));
        }

        public List<SlideViewModel> GetSlides(string groupAlias)
        {
            return _slideRepository.FindAll(x => x.Status && x.GroupAlias == groupAlias)
                .ProjectTo<SlideViewModel>().ToList();
        }

        public SystemConfigViewModel GetSystemConfig(string code)
        {
            return Mapper.Map<SystemConfig, SystemConfigViewModel>(_systemConfigRepository.FindSingle(x => x.Id == code));
        }
    }
}
