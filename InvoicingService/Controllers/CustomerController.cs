using InvoicingBusiness.Service;
using InvoicingData.Model;
using InvoicingRepository.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace InvoicingService.Controllers
{
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerService _Service;
        public CustomerController(ICustomerRepository pICustomerRepository)
        {
            _Service = new(pICustomerRepository);
        }

        [HttpPost]
        [Route("Api/Customer/Create")]
        public void Create([FromBody] Customer pCustomer)
        {
            _Service.Create(pCustomer);
        }

        [HttpDelete]
        [Route("Api/Customer/Delete")]
        public void Delete(int pId)
        {
            _Service.Delete(pId);
        }

        [HttpGet]
        [Route("Api/Customer/GetAll")]
        public IEnumerable<Customer> GetAll()
        {
            return _Service.GetAll();
        }

        [HttpGet]
        [Route("Api/Customer/GetById")]
        public Customer GetById(int pId)
        {
            return _Service.GetById(pId);
        }

        [HttpPut]
        [Route("Api/Customer/Update")]
        public void Update([FromBody]Customer pCustomer)
        {
            _Service.Update(pCustomer);
        }
    }
}
