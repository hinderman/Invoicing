﻿using InvoicingBusiness.Service;
using InvoicingData.Model;
using InvoicingRepository.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace InvoicingService.Controllers
{
    [Route("api/[controller]")]
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
        public bool Create([FromBody] Customer pCustomer)
        {
            return _Service.Create(pCustomer);
        }

        [HttpDelete]
        [Route("Api/Customer/Delete")]
        public bool Delete(int pDocument)
        {
            return _Service.Delete(pDocument);
        }

        [HttpGet]
        [Route("Api/Customer/GetAll")]
        public IEnumerable<Customer> GetAll()
        {
            return _Service.GetAll();
        }

        [HttpGet]
        [Route("Api/Customer/GetByDocument")]
        public Customer GetByDocument(int pDocument)
        {
            return _Service.GetByDocument(pDocument);
        }

        [HttpPut]
        [Route("Api/Customer/Update")]
        public bool Update(Customer pCustomer)
        {
            return _Service.Update(pCustomer);
        }
    }
}
