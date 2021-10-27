using InvoicingData.Model;
using System.Collections.Generic;

namespace InvoicingRepository.Interface
{
    public interface IInvoiceRepository
    {
        bool Create(Invoice pInvoice);

        IEnumerable<Invoice> GetAll();

        Invoice GetById(int pID);

        bool Delete(int pID);

        bool Update(Invoice pInvoice);
    }
}
