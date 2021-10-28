﻿using InvoicingData.Model;
using InvoicingRepository.Interface;
using System.Collections.Generic;

namespace InvoicingBusiness.Service
{
    public class CustomerService
    {
        private readonly ICustomerRepository _Repository;

        public CustomerService(ICustomerRepository pICustomerRepository)
        {
            _Repository = pICustomerRepository;
        }

        #region Methods

        public bool Create(Customer pCustomer)
        {
            return _Repository.Create(pCustomer);
        }

        public bool Delete(int pDocument)
        {
            return _Repository.Delete(pDocument);
        }

        public IEnumerable<Customer> GetAll()
        {
            return _Repository.GetAll();
        }

        public Customer GetByDocument(int pDocument)
        {
            return _Repository.GetByDocument(pDocument);
        }

        public bool Update(Customer pCustomer)
        {
            return _Repository.Update(pCustomer);
        }

        #endregion Methods
    }
}
