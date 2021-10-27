using InvoicingData.Model;
using System.Collections.Generic;

namespace InvoicingRepository.Interface
{
    public interface ICustomerRepository
    {
        bool Create(Customer pCustomer);

        IEnumerable<Customer> GetAll();

        Customer GetByDocument(int pDocument);

        bool Delete(int pCustomerID);

        bool Update(Customer pCustomer);
    }
}
