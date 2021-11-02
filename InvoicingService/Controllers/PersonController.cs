using InvoicingBusiness.Service;
using InvoicingData.Model;
using InvoicingRepository.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace InvoicingService.Controllers
{
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly PersonService _Service;
        public PersonController(IPersonRepository pIPersonRepository)
        {
            _Service = new(pIPersonRepository);
        }

        [HttpPost]
        [Route("Api/Person/Create")]
        public void Create([FromBody] Person pPerson)
        {
            _Service.Create(pPerson);
        }

        [HttpDelete]
        [Route("Api/Person/Delete")]
        public void Delete(int pId)
        {
            _Service.Delete(pId);
        }

        [HttpGet]
        [Route("Api/Person/GetAll")]
        public IEnumerable<Person> GetAll()
        {
            return _Service.GetAll();
        }

        [HttpGet]
        [Route("Api/Person/GetById")]
        public Person GetById(int pId)
        {
            return _Service.GetById(pId);
        }

        [HttpPut]
        [Route("Api/Person/Update")]
        public void Update([FromBody] Person pPerson)
        {
            _Service.Update(pPerson);
        }
    }
}
