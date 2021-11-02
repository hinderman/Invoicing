using InvoicingData.Model;
using System.Collections.Generic;

namespace InvoicingRepository.Interface
{
    public interface IPhoneRepository
    {
        void Create(Phone pPhone);

        IEnumerable<Phone> GetAll();

        IEnumerable<Phone> GetByIdPerson(int pIdPerson);

        Phone GetById(int pID);

        void Delete(int pID);

        void Update(Phone pPhone);
    }
}