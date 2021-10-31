using InvoicingData.Model;
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

        public void Create(Customer pCustomer)
        {
            _Repository.Create(pCustomer);
        }

        public void Delete(int pId)
        {
            _Repository.Delete(pId);
        }

        public IEnumerable<Customer> GetAll()
        {
            return _Repository.GetAll();
        }

        public Customer GetById(int pId)
        {
            return _Repository.GetById(pId);
        }

        public void Update(Customer pCustomer)
        {
            _Repository.Update(pCustomer);
        }

        #endregion Methods
    }
}
