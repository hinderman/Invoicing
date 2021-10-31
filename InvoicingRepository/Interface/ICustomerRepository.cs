using InvoicingData.Model;
using System.Collections.Generic;

namespace InvoicingRepository.Interface
{
    public interface ICustomerRepository
    {
        void Create(Customer pCustomer);

        IEnumerable<Customer> GetAll();

        Customer GetById(int pId);

        void Delete(int pId);

        void Update(Customer pCustomer);
    }
}
