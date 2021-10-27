using InvoicingBusiness.Service;
using InvoicingData.Model;
using InvoicingRepository.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace InvoicingService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerService _CustomerService;
        public CustomerController(ICustomerRepository pICustomerRepository)
        {
            _CustomerService = new(pICustomerRepository);
        }

        [HttpPost]
        [Route("Api/Customer/Create")]
        public bool Create([FromBody]Customer pCustomer)
        {
            throw new NotImplementedException();
        }

        [HttpDelete]
        [Route("Api/Customer/Delete")]
        public bool Delete(int pCustomerID)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route("Api/Customer/GetAll")]
        public IEnumerable<Customer> GetAll()
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route("Api/Customer/GetByDocument")]
        public Customer GetByDocument(int pDocument)
        {
            return _CustomerService.GetByDocument(pDocument);
        }

        [HttpPut]
        [Route("Api/Customer/Update")]
        public Customer Update(Customer pCustomer)
        {
            throw new NotImplementedException();
        }
    }
}
