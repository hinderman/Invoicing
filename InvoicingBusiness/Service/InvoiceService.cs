using InvoicingData.Model;
using InvoicingRepository.Interface;
using System.Collections.Generic;

namespace InvoicingBusiness.Service
{
    public class InvoiceService
    {
        private readonly IInvoiceRepository _Repository;

        public InvoiceService(IInvoiceRepository pIInvoiceRepository)
        {
            _Repository = pIInvoiceRepository;
        }

        #region Methods

        public bool Create(Invoice pInvoice)
        {
            return _Repository.Create(pInvoice);
        }

        public bool Delete(int pId)
        {
            return _Repository.Delete(pId);
        }

        public IEnumerable<Invoice> GetAll()
        {
            return _Repository.GetAll();
        }

        public Invoice GetById(int pId)
        {
            return _Repository.GetById(pId);
        }

        public bool Update(Invoice pInvoice)
        {
            return _Repository.Update(pInvoice);
        }

        #endregion Methods
    }
}