﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using InitialCore.Service.Interfaces;
using InitialCore.Service.ViewModels.Common;
using InitialCore.Data.Entities;
using InitialCore.Infrastructure.Interfaces;
using InitialCore.Utilities.Dtos;

namespace InitialCore.Service.Implementation
{
    public class ContactService : IContactService
    {
        private IRepository<Contact, string> _contactRepository;
        private IUnitOfWork _unitOfWork;

        public ContactService(IRepository<Contact, string> contactRepository,
            IUnitOfWork unitOfWork)
        {
            this._contactRepository = contactRepository;
            this._unitOfWork = unitOfWork;
        }

        public void Add(ContactViewModel pageVm)
        {
            var page = Mapper.Map<ContactViewModel, Contact>(pageVm);
            _contactRepository.Add(page);
        }

        public void Delete(string id)
        {
            _contactRepository.Remove(id);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public List<ContactViewModel> GetAll()
        {
            return _contactRepository.FindAll().ProjectTo<ContactViewModel>().ToList();
        }

        public PagedResult<ContactViewModel> GetAllPaging(string keyword, int page, int pageSize)
        {
            var query = _contactRepository.FindAll();
            if (!string.IsNullOrEmpty(keyword))
                query = query.Where(x => x.Name.Contains(keyword));

            int totalRow = query.Count();
            var data = query.OrderByDescending(x => x.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize);

            var paginationSet = new PagedResult<ContactViewModel>()
            {
                Results = data.ProjectTo<ContactViewModel>().ToList(),
                CurrentPage = page,
                RowCount = totalRow,
                PageSize = pageSize
            };

            return paginationSet;
        }

        public ContactViewModel GetById(string id)
        {
            return Mapper.Map<Contact, ContactViewModel>(_contactRepository.FindById(id));
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(ContactViewModel pageVm)
        {
            var page = Mapper.Map<ContactViewModel, Contact>(pageVm);
            _contactRepository.Update(page);
        }
    }
}