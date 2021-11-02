using InvoicingPresentation.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace InvoicingPresentation.Controllers
{
    public class InvoicingController : Controller
    {
        private readonly IOptions<ConfigurationManager> _Service;

        public InvoicingController(IOptions<ConfigurationManager> pConfiguration)
        {
            _Service = pConfiguration;
        }

        [HttpGet]
        public async Task<IEnumerable<Invoicing>> GetAll()
        {
            try
            {
                List<Invoicing> lstInvoicing = new();
                using (HttpClient _HttpClient = new())
                {
                    HttpResponseMessage responseMessage = await _HttpClient.GetAsync(_Service.Value.BaseAddressApi + "Api/Invoicing/GetAll");
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        lstInvoicing = JsonConvert.DeserializeObject<List<Invoicing>>(await responseMessage.Content.ReadAsStringAsync());
                    }
                }
                return lstInvoicing;
            }
            catch (Exception exception)
            {
                throw new Exception(string.Concat("Error del servidor: ", exception.Message), exception);
            }
        }

        [HttpGet]
        public async Task<Invoicing> GetById(int pId)
        {
            try
            {
                Invoicing objInvoicing = new();
                using (HttpClient _HttpClient = new())
                {
                    HttpResponseMessage responseMessage = await _HttpClient.GetAsync(_Service.Value.BaseAddressApi + "Api/Invoicing/GetById?pId=" + pId);
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        objInvoicing = JsonConvert.DeserializeObject<Invoicing>(await responseMessage.Content.ReadAsStringAsync());
                    }
                }
                return objInvoicing;
            }
            catch (Exception exception)
            {
                throw new Exception(string.Concat("Error del servidor: ", exception.Message), exception);
            }
        }

        [HttpPut]
        public async void Update([FromBody] Invoicing pInvoicing)
        {
            try
            {
                using (HttpClient _HttpClient = new())
                {
                    string strInvoicing = JsonConvert.SerializeObject(pInvoicing);
                    HttpContent _HttpContent = new StringContent(strInvoicing, Encoding.UTF8, "application/json");
                    HttpResponseMessage responseMessage = await _HttpClient.PutAsync(_Service.Value.BaseAddressApi + "Api/Invoicing/Update", _HttpContent);
                    if (!responseMessage.IsSuccessStatusCode)
                    {
                        throw new Exception(string.Concat("Error del servidor: Se presento un error al momento de la eliminación"));
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
                    HttpResponseMessage responseMessage = await _HttpClient.DeleteAsync(_Service.Value.BaseAddressApi + "Api/Invoicing/Delete?pId=" + pId);
                    if (!responseMessage.IsSuccessStatusCode)
                    {
                        throw new Exception(string.Concat("Error del servidor: Se presento un error al momento de la eliminación"));
                    }
                }
            }
            catch (Exception exception)
            {
                throw new Exception(string.Concat("Error del servidor: ", exception.Message), exception);
            }
        }

        [HttpPost]
        public async void Create([FromBody] Invoicing pInvoicing)
        {
            try
            {
                using (HttpClient _HttpClient = new())
                {
                    string strInvoicing = JsonConvert.SerializeObject(pInvoicing);
                    HttpContent _HttpContent = new StringContent(strInvoicing, Encoding.UTF8, "application/json");
                    HttpResponseMessage responseMessage = await _HttpClient.PostAsync(_Service.Value.BaseAddressApi + "Api/Invoicing/Create", _HttpContent);
                    if (!responseMessage.IsSuccessStatusCode)
                    {
                        throw new Exception(string.Concat("Error del servidor: Se presento un error al momento de la creación"));
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
