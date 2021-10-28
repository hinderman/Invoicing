using InvoicingData.Model;
using InvoicingRepository.Interface;
using System.Collections.Generic;

namespace InvoicingBusiness.Service
{
    public class CategoryService
    {
        private readonly ICategoryRepository _Repository;

        public CategoryService(ICategoryRepository pICategoryRepository)
        {
            _Repository = pICategoryRepository;
        }

        #region Methods

        public bool Create(Category pCategory)
        {
            return _Repository.Create(pCategory);
        }

        public bool Delete(int pId)
        {
            return _Repository.Delete(pId);
        }

        public IEnumerable<Category> GetAll()
        {
            return _Repository.GetAll();
        }

        public Category GetById(int pId)
        {
            return _Repository.GetById(pId);
        }

        public bool Update(Category pCategory)
        {
            return _Repository.Update(pCategory);
        }

        #endregion Methods
    }
}
