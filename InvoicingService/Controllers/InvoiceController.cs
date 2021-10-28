using InvoicingBusiness.Service;
using InvoicingData.Model;
using InvoicingRepository.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace InvoicingService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly InvoiceService _Service;
        public InvoiceController(IInvoiceRepository pIInvoiceRepository)
        {
            _Service = new(pIInvoiceRepository);
        }

        [HttpPost]
        [Route("Api/Invoice/Create")]
        public bool Create([FromBody] Invoice pInvoice)
        {
            return _Service.Create(pInvoice);
        }

        [HttpDelete]
        [Route("Api/Invoice/Delete")]
        public bool Delete(int pId)
        {
            return _Service.Delete(pId);
        }

        [HttpGet]
        [Route("Api/Invoice/GetAll")]
        public IEnumerable<Invoice> GetAll()
        {
            return _Service.GetAll();
        }

        [HttpGet]
        [Route("Api/Invoice/GetByDocument")]
        public Invoice GetById(int pId)
        {
            return _Service.GetById(pId);
        }

        [HttpPut]
        [Route("Api/Invoice/Update")]
        public bool Update(Invoice pCustomer)
        {
            return _Service.Update(pCustomer);
        }
    }
}