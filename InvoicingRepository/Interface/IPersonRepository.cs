using InvoicingData.Model;
using System.Collections.Generic;

namespace InvoicingRepository.Interface
{
    public interface IPersonRepository
    {
        void Create(Person pPerson);

        IEnumerable<Person> GetAll();

        Person GetById(int pId);

        void Delete(int pId);

        void Update(Person pPerson);
    }
}
