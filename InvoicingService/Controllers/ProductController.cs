using InvoicingBusiness.Service;
using InvoicingData.Model;
using InvoicingRepository.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace InvoicingService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _Service;
        public ProductController(IProductRepository pIProductRepository)
        {
            _Service = new(pIProductRepository);
        }

        [HttpPost]
        [Route("Api/Product/Create")]
        public bool Create([FromBody] Product pProduct)
        {
            return _Service.Create(pProduct);
        }

        [HttpDelete]
        [Route("Api/Product/Delete")]
        public bool Delete(int pId)
        {
            return _Service.Delete(pId);
        }

        [HttpGet]
        [Route("Api/Product/GetAll")]
        public IEnumerable<Product> GetAll()
        {
            return _Service.GetAll();
        }

        [HttpGet]
        [Route("Api/Product/GetByDocument")]
        public Product GetById(int pId)
        {
            return _Service.GetById(pId);
        }

        [HttpPut]
        [Route("Api/Product/Update")]
        public bool Update(Product pCustomer)
        {
            return _Service.Update(pCustomer);
        }
    }
}
