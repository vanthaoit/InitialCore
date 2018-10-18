using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using InitialCore.Service.ViewModels.System;
using InitialCore.Utilities.Dtos;

namespace InitialCore.Service.Interfaces
{
    public interface IRoleService
    {
        Task<bool> AddAsync(ApplicationRoleViewModel userVm);

        Task DeleteAsync(Guid id);

        Task<List<ApplicationRoleViewModel>> GetAllAsync();

        PagedResult<ApplicationRoleViewModel> GetAllPagingAsync(string keyword, int page, int pageSize);

        Task<ApplicationRoleViewModel> GetById(Guid id);


        Task UpdateAsync(ApplicationRoleViewModel userVm);

        List<PermissionViewModel> GetListFunctionWithRole(Guid roleId);

        void SavePermission(List<PermissionViewModel> permissions, Guid roleId);

        Task<bool> CheckPermission(string functionId, string action, string[] roles);
    }
}
