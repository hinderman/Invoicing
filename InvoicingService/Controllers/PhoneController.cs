using InvoicingBusiness.Service;
using InvoicingData.Model;
using InvoicingRepository.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace InvoicingService.Controllers
{
    public class PhoneController : Controller
    {
        private readonly PhoneService _Service;
        public PhoneController(IPhoneRepository pIPhoneRepository)
        {
            _Service = new(pIPhoneRepository);
        }

        [HttpPost]
        [Route("Api/Phone/Create")]
        public void Create([FromBody] Phone pPhone)
        {
            _Service.Create(pPhone);
        }

        [HttpDelete]
        [Route("Api/Phone/Delete")]
        public void Delete(int pId)
        {
            _Service.Delete(pId);
        }

        [HttpGet]
        [Route("Api/Phone/GetAll")]
        public IEnumerable<Phone> GetAll()
        {
            return _Service.GetAll();
        }

        [HttpGet]
        [Route("Api/Phone/GetByIdPerson")]
        public IEnumerable<Phone> GetByIdPerson(int pIdPerson)
        {
            return _Service.GetByIdPerson(pIdPerson);
        }

        [HttpGet]
        [Route("Api/Phone/GetById")]
        public Phone GetById(int pId)
        {
            return _Service.GetById(pId);
        }

        [HttpPut]
        [Route("Api/Phone/Update")]
        public void Update([FromBody] Phone pPhone)
        {
            _Service.Update(pPhone);
        }
    }
}
