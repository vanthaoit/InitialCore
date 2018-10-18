using System;
using System.Collections.Generic;
using System.Text;
using InitialCore.Service.ViewModels.Common;

namespace InitialCore.Service.Interfaces
{
    public interface ICommonService
    {
        FooterViewModel GetFooter();
        List<SlideViewModel> GetSlides(string groupAlias);
        SystemConfigViewModel GetSystemConfig(string code);
    }
}
