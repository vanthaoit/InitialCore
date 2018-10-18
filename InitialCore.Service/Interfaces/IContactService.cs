using System;
using System.Collections.Generic;
using System.Text;
using InitialCore.Service.ViewModels.Common;
using InitialCore.Utilities.Dtos;

namespace InitialCore.Service.Interfaces
{
   public  interface IContactService
    {
        void Add(ContactViewModel contactVm);

        void Update(ContactViewModel contactVm);

        void Delete(string id);

        List<ContactViewModel> GetAll();

        PagedResult<ContactViewModel> GetAllPaging(string keyword, int page, int pageSize);

        ContactViewModel GetById(string id);

        void SaveChanges();
    }
}
