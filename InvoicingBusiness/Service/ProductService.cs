using InvoicingData.Model;
using InvoicingRepository.Interface;
using System.Collections.Generic;

namespace InvoicingBusiness.Service
{
    public class ProductService
    {
        private readonly IProductRepository _Repository;

        public ProductService(IProductRepository pIProductRepository)
        {
            _Repository = pIProductRepository;
        }

        #region Methods

        public bool Create(Product pProduct)
        {
            return _Repository.Create(pProduct);
        }

        public bool Delete(int pId)
        {
            return _Repository.Delete(pId);
        }

        public IEnumerable<Product> GetAll()
        {
            return _Repository.GetAll();
        }

        public Product GetById(int pId)
        {
            return _Repository.GetById(pId);
        }

        public bool Update(Product pProduct)
        {
            return _Repository.Update(pProduct);
        }

        #endregion Methods
    }
}