using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using InitialCore.Service.Interfaces;
using InitialCore.Service.ViewModels.System;
using InitialCore.Utilities.Constants;
using InitialCore.Extensions;

namespace InitialCore.Areas.Admin.Components
{
    public class SideBarViewComponent : ViewComponent
    {
        private IFunctionService _functionService;

        public SideBarViewComponent(IFunctionService functionService)
        {
            _functionService = functionService;
        }

        public async Task<IViewComponentResult> InvokeAsync()   
        {
            var roles = ((ClaimsPrincipal)User).GetSpecificClaim("Roles");
            List<FunctionViewModel> functions;
            if (roles.Split(";").Contains(CommonConstants.ApplicationRole.AdminRole))
            {
                functions = await _functionService.GetAll(string.Empty);
            }
            else
            {
                //TODO: Get by permission
                functions = await _functionService.GetAll(string.Empty);
            }
            return View(functions);
        }
    }
}