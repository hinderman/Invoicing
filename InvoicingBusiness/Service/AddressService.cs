using InvoicingData.Model;
using InvoicingRepository.Interface;
using System.Collections.Generic;

namespace InvoicingBusiness.Service
{
    public class AddressService
    {
        private readonly IAddressRepository _Repository;

        public AddressService(IAddressRepository pIAddressRepository)
        {
            _Repository = pIAddressRepository;
        }

        #region Methods

        public void Create(Address pAddress)
        {
            _Repository.Create(pAddress);
        }

        public void Delete(int pId)
        {
            _Repository.Delete(pId);
        }

        public IEnumerable<Address> GetAll()
        {
            return _Repository.GetAll();
        }

        public IEnumerable<Address> GetByIdPerson(int pIdPerson)
        {
            return _Repository.GetByIdPerson(pIdPerson);
        }

        public Address GetById(int pId)
        {
            return _Repository.GetById(pId);
        }

        public void Update(Address pAddress)
        {
            _Repository.Update(pAddress);
        }

        #endregion Methods
    }
}
