using InvoicingData.Model;
using System.Collections.Generic;

namespace InvoicingRepository.Interface
{
    public interface IProductRepository
    {
        bool Create(Product pProduct);

        IEnumerable<Product> GetAll();

        Product GetById(int pID);

        bool Delete(int pID);

        bool Update(Product pProduct);
    }
}
