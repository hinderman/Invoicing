using InvoicingBusiness.Service;
using InvoicingData.Model;
using InvoicingRepository.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace InvoicingService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellerController : ControllerBase
    {
        private readonly SellerService _Service;
        public SellerController(ISellerRepository pISellerRepository)
        {
            _Service = new(pISellerRepository);
        }

        [HttpPost]
        [Route("Api/Seller/Create")]
        public bool Create([FromBody] Seller pSeller)
        {
            return _Service.Create(pSeller);
        }

        [HttpDelete]
        [Route("Api/Seller/Delete")]
        public bool Delete(int pDocument)
        {
            return _Service.Delete(pDocument);
        }

        [HttpGet]
        [Route("Api/Seller/GetAll")]
        public IEnumerable<Seller> GetAll()
        {
            return _Service.GetAll();
        }

        [HttpGet]
        [Route("Api/Seller/GetByDocument")]
        public Seller GetByDocument(int pDocument)
        {
            return _Service.GetByDocument(pDocument);
        }

        [HttpPut]
        [Route("Api/Seller/Update")]
        public bool Update(Seller pCustomer)
        {
            return _Service.Update(pCustomer);
        }
    }
}
