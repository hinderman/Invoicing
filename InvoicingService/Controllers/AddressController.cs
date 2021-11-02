using InvoicingBusiness.Service;
using InvoicingData.Model;
using InvoicingRepository.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace InvoicingService.Controllers
{
    public class AddressController : Controller
    {
        private readonly AddressService _Service;
        public AddressController(IAddressRepository pIAddressRepository)
        {
            _Service = new(pIAddressRepository);
        }

        [HttpPost]
        [Route("Api/Address/Create")]
        public void Create([FromBody] Address pAddress)
        {
            _Service.Create(pAddress);
        }

        [HttpDelete]
        [Route("Api/Address/Delete")]
        public void Delete(int pId)
        {
            _Service.Delete(pId);
        }

        [HttpGet]
        [Route("Api/Address/GetAll")]
        public IEnumerable<Address> GetAll()
        {
            return _Service.GetAll();
        }

        [HttpGet]
        [Route("Api/Address/GetByIdPerson")]
        public IEnumerable<Address> GetByIdPerson(int pIdPerson)
        {
            return _Service.GetByIdPerson(pIdPerson);
        }

        [HttpGet]
        [Route("Api/Address/GetById")]
        public Address GetById(int pId)
        {
            return _Service.GetById(pId);
        }

        [HttpPut]
        [Route("Api/Address/Update")]
        public void Update([FromBody] Address pAddress)
        {
            _Service.Update(pAddress);
        }
    }
}
