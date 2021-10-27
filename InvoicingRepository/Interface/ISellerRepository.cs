using InvoicingData.Model;
using System.Collections.Generic;

namespace InvoicingRepository.Interface
{
    public interface ISellerRepository
    {
        bool Create(Seller pSeller);

        IEnumerable<Seller> GetAll();

        Seller GetByDocument(int pDocument);

        bool Delete(int pDocument);

        bool Update(Seller pSeller);
    }
}
