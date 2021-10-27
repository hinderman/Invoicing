using InvoicingData.Model;
using System.Collections.Generic;

namespace InvoicingRepository.Interface
{
    public interface ICategoryRepository
    {
        bool Create(Category pCategory);

        IEnumerable<Category> GetAll();

        Category GetById(int pID);

        bool Delete(int pID);

        bool Update(Category pCategory);
    }
}
