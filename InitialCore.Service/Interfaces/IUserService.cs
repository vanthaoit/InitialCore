using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using InitialCore.Service.ViewModels.System;
using InitialCore.Utilities.Dtos;

namespace InitialCore.Service.Interfaces
{
    public interface IUserService
    {
        Task<bool> AddAsync(ApplicationUserViewModel userVm);

        Task DeleteAsync(string id);

        Task<List<ApplicationUserViewModel>> GetAllAsync();

        PagedResult<ApplicationUserViewModel> GetAllPagingAsync(string keyword, int page, int pageSize);

        Task<ApplicationUserViewModel> GetById(string id);


        Task UpdateAsync(ApplicationUserViewModel userVm);
    }
}
