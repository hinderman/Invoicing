using InvoicingData.Model;
using InvoicingRepository.Interface;
using System.Collections.Generic;

namespace InvoicingBusiness.Service
{
    public class EmailService
    {
        private readonly IEmailRepository _Repository;

        public EmailService(IEmailRepository pIEmailRepository)
        {
            _Repository = pIEmailRepository;
        }

        #region Methods

        public void Create(Email pEmail)
        {
            _Repository.Create(pEmail);
        }

        public void Delete(int pId)
        {
            _Repository.Delete(pId);
        }

        public IEnumerable<Email> GetAll()
        {
            return _Repository.GetAll();
        }

        public IEnumerable<Email> GetByIdPerson(int pIdPerson)
        {
            return _Repository.GetByIdPerson(pIdPerson);
        }

        public Email GetById(int pId)
        {
            return _Repository.GetById(pId);
        }

        public void Update(Email pEmail)
        {
            _Repository.Update(pEmail);
        }

        #endregion Methods
    }
}
