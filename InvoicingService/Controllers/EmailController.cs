using InvoicingBusiness.Service;
using InvoicingData.Model;
using InvoicingRepository.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace InvoicingService.Controllers
{
    public class EmailController : Controller
    {
        private readonly EmailService _Service;
        public EmailController(IEmailRepository pIEmailRepository)
        {
            _Service = new(pIEmailRepository);
        }

        [HttpPost]
        [Route("Api/Email/Create")]
        public void Create([FromBody] Email pEmail)
        {
            _Service.Create(pEmail);
        }

        [HttpDelete]
        [Route("Api/Email/Delete")]
        public void Delete(int pId)
        {
            _Service.Delete(pId);
        }

        [HttpGet]
        [Route("Api/Email/GetAll")]
        public IEnumerable<Email> GetAll()
        {
            return _Service.GetAll();
        }

        [HttpGet]
        [Route("Api/Email/GetByIdPerson")]
        public IEnumerable<Email> GetByIdPerson(int pIdPerson)
        {
            return _Service.GetByIdPerson(pIdPerson);
        }

        [HttpGet]
        [Route("Api/Email/GetById")]
        public Email GetById(int pId)
        {
            return _Service.GetById(pId);
        }

        [HttpPut]
        [Route("Api/Email/Update")]
        public void Update([FromBody] Email pEmail)
        {
            _Service.Update(pEmail);
        }
    }
}
