using InvoicingData.Model;
using InvoicingRepository.Interface;
using System.Collections.Generic;

namespace InvoicingBusiness.Service
{
    public class PersonService
    {
        private readonly IPersonRepository _Repository;

        public PersonService(IPersonRepository pIPersonRepository)
        {
            _Repository = pIPersonRepository;
        }

        #region Methods

        public void Create(Person pPerson)
        {
            _Repository.Create(pPerson);
        }

        public void Delete(int pId)
        {
            _Repository.Delete(pId);
        }

        public IEnumerable<Person> GetAll()
        {
            return _Repository.GetAll();
        }

        public Person GetById(int pId)
        {
            return _Repository.GetById(pId);
        }

        public void Update(Person pPerson)
        {
            _Repository.Update(pPerson);
        }

        #endregion Methods
    }
}
