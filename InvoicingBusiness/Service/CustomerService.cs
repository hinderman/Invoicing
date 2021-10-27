using InvoicingData.Model;
using InvoicingRepository.Interface;
using System;
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

        public bool Create(Customer pCustomer)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int pCustomerID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> GetAll()
        {
            throw new NotImplementedException();
        }

        public Customer GetByDocument(int pDocument)
        {
            return _Repository.GetByDocument(pDocument);
        }

        public Customer Update(Customer pCustomer)
        {
            throw new NotImplementedException();
        }
    }
}
