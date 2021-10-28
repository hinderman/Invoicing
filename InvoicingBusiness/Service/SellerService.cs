using InvoicingData.Model;
using InvoicingRepository.Interface;
using System.Collections.Generic;

namespace InvoicingBusiness.Service
{
    public class SellerService
    {
        private readonly ISellerRepository _Repository;

        public SellerService(ISellerRepository pISellerRepository)
        {
            _Repository = pISellerRepository;
        }

        #region Methods

        public bool Create(Seller pSeller)
        {
            return _Repository.Create(pSeller);
        }

        public bool Delete(int pDocument)
        {
            return _Repository.Delete(pDocument);
        }

        public IEnumerable<Seller> GetAll()
        {
            return _Repository.GetAll();
        }

        public Seller GetByDocument(int pDocument)
        {
            return _Repository.GetByDocument(pDocument);
        }

        public bool Update(Seller pSeller)
        {
            return _Repository.Update(pSeller);
        }

        #endregion Methods
    }
}
