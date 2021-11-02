using InvoicingData.Model;
using System.Collections.Generic;

namespace InvoicingRepository.Interface
{
    public interface IEmailRepository
    {
        void Create(Email pEmail);

        IEnumerable<Email> GetAll();

        IEnumerable<Email> GetByIdPerson(int pIdPerson);

        Email GetById(int pID);

        void Delete(int pID);

        void Update(Email pEmail);
    }
}