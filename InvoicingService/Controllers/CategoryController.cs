using InvoicingBusiness.Service;
using InvoicingData.Model;
using InvoicingRepository.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace InvoicingService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly CategoryService _Service;
        public CategoryController(ICategoryRepository pICategoryRepository)
        {
            _Service = new(pICategoryRepository);
        }

        [HttpPost]
        [Route("Api/Category/Create")]
        public bool Create([FromBody] Category pCategory)
        {
            return _Service.Create(pCategory);
        }

        [HttpDelete]
        [Route("Api/Category/Delete")]
        public bool Delete(int pId)
        {
            return _Service.Delete(pId);
        }

        [HttpGet]
        [Route("Api/Category/GetAll")]
        public IEnumerable<Category> GetAll()
        {
            return _Service.GetAll();
        }

        [HttpGet]
        [Route("Api/Category/GetByDocument")]
        public Category GetById(int pId)
        {
            return _Service.GetById(pId);
        }

        [HttpPut]
        [Route("Api/Category/Update")]
        public bool Update(Category pCustomer)
        {
            return _Service.Update(pCustomer);
        }
    }
}