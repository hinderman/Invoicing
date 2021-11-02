using InvoicingData.Model;
using System.Collections.Generic;

namespace InvoicingRepository.Interface
{
    public interface IAddressRepository
    {
        void Create(Address pAddress);

        IEnumerable<Address> GetAll();

        IEnumerable<Address> GetByIdPerson(int pIdPerson);

        Address GetById(int pID);

        void Delete(int pID);

        void Update(Address pAddress);
    }
}