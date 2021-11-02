using InvoicingData.Model;
using InvoicingRepository.Interface;
using System.Collections.Generic;

namespace InvoicingBusiness.Service
{
    public class PhoneService
    {
        private readonly IPhoneRepository _Repository;

        public PhoneService(IPhoneRepository pIPhoneRepository)
        {
            _Repository = pIPhoneRepository;
        }

        #region Methods

        public void Create(Phone pPhone)
        {
            _Repository.Create(pPhone);
        }

        public void Delete(int pId)
        {
            _Repository.Delete(pId);
        }

        public IEnumerable<Phone> GetAll()
        {
            return _Repository.GetAll();
        }

        public IEnumerable<Phone> GetByIdPerson(int pIdPerson)
        {
            return _Repository.GetByIdPerson(pIdPerson);
        }

        public Phone GetById(int pId)
        {
            return _Repository.GetById(pId);
        }

        public void Update(Phone pPhone)
        {
            _Repository.Update(pPhone);
        }

        #endregion Methods
    }
}
