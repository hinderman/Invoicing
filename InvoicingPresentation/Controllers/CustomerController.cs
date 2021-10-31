using InvoicingPresentation.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace InvoicingPresentation.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IOptions<ConfigurationManager> _Service;

        public CustomerController(IOptions<ConfigurationManager> pConfiguration)
        {
            _Service = pConfiguration;
        }

        [HttpGet]
        public async Task<IEnumerable<Customer>> GetAll()
        {
            try
            {
                List<Customer> lstCustomer = new();
                using (HttpClient _HttpClient = new())
                {
                    HttpResponseMessage responseMessage = await _HttpClient.GetAsync(_Service.Value.BaseAddressApi + "Api/Customer/GetAll");
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        lstCustomer = JsonConvert.DeserializeObject<List<Customer>>(await responseMessage.Content.ReadAsStringAsync());
                    }
                }
                return lstCustomer;
            }
            catch (Exception exception)
            {
                throw new Exception(string.Concat("Error del servidor: ", exception.Message), exception);
            }
        }

        [HttpGet]
        public async Task<Customer> GetById(int pId)
        {
            try
            {
                Customer objCustomer = new();
                using (HttpClient _HttpClient = new())
                {
                    HttpResponseMessage responseMessage = await _HttpClient.GetAsync(_Service.Value.BaseAddressApi + "Api/Customer/GetById?pId=" + pId);
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        objCustomer = JsonConvert.DeserializeObject<Customer>(await responseMessage.Content.ReadAsStringAsync());
                    }
                }
                return objCustomer;
            }
            catch (Exception exception)
            {
                throw new Exception(string.Concat("Error del servidor: ", exception.Message), exception);
            }
        }

        [HttpPut]
        public async void Update([FromBody] Customer pCustomer)
        {
            try
            {
                using (HttpClient _HttpClient = new())
                {
                    string strCustomer = JsonConvert.SerializeObject(pCustomer);
                    HttpContent _HttpContent = new StringContent(strCustomer, Encoding.UTF8, "application/json");
                    HttpResponseMessage responseMessage = await _HttpClient.PutAsync(_Service.Value.BaseAddressApi + "Api/Customer/Update", _HttpContent);
                    if (responseMessage.IsSuccessStatusCode)
                    {
                    }
                }
            }
            catch (Exception exception)
            {
                throw new Exception(string.Concat("Error del servidor: ", exception.Message), exception);
            }
        }

        [HttpDelete]
        public async void Delete(int pId)
        {
            try
            {
                using (HttpClient _HttpClient = new())
                {
                    HttpResponseMessage responseMessage = await _HttpClient.DeleteAsync(_Service.Value.BaseAddressApi + "Api/Customer/Delete?pId=" + pId);
                    if (responseMessage.IsSuccessStatusCode)
                    {
                    }
                }
            }
            catch (Exception exception)
            {
                throw new Exception(string.Concat("Error del servidor: ", exception.Message), exception);
            }
        }

        [HttpPost]
        public async void Create([FromBody] Customer pCustomer)
        {
            try
            {
                using (HttpClient _HttpClient = new())
                {
                    string strCustomer = JsonConvert.SerializeObject(pCustomer);
                    HttpContent _HttpContent = new StringContent(strCustomer, Encoding.UTF8, "application/json");
                    HttpResponseMessage responseMessage = await _HttpClient.PostAsync(_Service.Value.BaseAddressApi + "Api/Customer/Create", _HttpContent);
                    if (responseMessage.IsSuccessStatusCode)
                    {
                    }
                }
            }
            catch (Exception exception)
            {
                throw new Exception(string.Concat("Error del servidor: ", exception.Message), exception);
            }
        }
    }
}
