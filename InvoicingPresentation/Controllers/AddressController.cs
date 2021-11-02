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
    public class AddressController : Controller
    {
        private readonly IOptions<ConfigurationManager> _Service;

        public AddressController(IOptions<ConfigurationManager> pConfiguration)
        {
            _Service = pConfiguration;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<Address>> GetAll()
        {
            try
            {
                List<Address> lstAddress = new();
                using (HttpClient _HttpClient = new())
                {
                    HttpResponseMessage responseMessage = await _HttpClient.GetAsync(_Service.Value.BaseAddressApi + "Api/Address/GetAll");
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        lstAddress = JsonConvert.DeserializeObject<List<Address>>(await responseMessage.Content.ReadAsStringAsync());
                    }
                }
                return lstAddress;
            }
            catch (Exception exception)
            {
                throw new Exception(string.Concat("Error del servidor: ", exception.Message), exception);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pIdPerson"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<Address>> GetByIdPerson(int pIdPerson)
        {
            try
            {
                List<Address> lstAddress = new();
                using (HttpClient _HttpClient = new())
                {
                    HttpResponseMessage responseMessage = await _HttpClient.GetAsync(_Service.Value.BaseAddressApi + "Api/Address/GetByIdPerson?pIdPerson=" + pIdPerson);
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        lstAddress = JsonConvert.DeserializeObject<List<Address>>(await responseMessage.Content.ReadAsStringAsync());
                    }
                }
                return lstAddress;
            }
            catch (Exception exception)
            {
                throw new Exception(string.Concat("Error del servidor: ", exception.Message), exception);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pAddress"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<HttpResponseMessage> Update([FromBody] Address pAddress)
        {
            try
            {
                using (HttpClient _HttpClient = new())
                {
                    string strAddress = JsonConvert.SerializeObject(pAddress);
                    HttpContent _HttpContent = new StringContent(strAddress, Encoding.UTF8, "application/json");
                    HttpResponseMessage responseMessage = await _HttpClient.PutAsync(_Service.Value.BaseAddressApi + "Api/Address/Update", _HttpContent);
                    return responseMessage;
                }
            }
            catch (Exception exception)
            {
                throw new Exception(string.Concat("Se presento un error al momento de enviar los datos al servidor: ", exception));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pId"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<HttpResponseMessage> Delete(int pId)
        {
            try
            {
                using (HttpClient _HttpClient = new())
                {
                    HttpResponseMessage responseMessage = await _HttpClient.DeleteAsync(_Service.Value.BaseAddressApi + "Api/Address/Delete?pId=" + pId);
                    return responseMessage;
                }
            }
            catch (Exception exception)
            {
                throw new Exception(string.Concat("Se presento un error al momento de enviar los datos al servidor: ", exception));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pAddress"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<HttpResponseMessage> Create([FromBody] Address pAddress)
        {
            try
            {
                using (HttpClient _HttpClient = new())
                {
                    string strAddress = JsonConvert.SerializeObject(pAddress);
                    HttpContent _HttpContent = new StringContent(strAddress, Encoding.UTF8, "application/json");
                    HttpResponseMessage responseMessage = await _HttpClient.PostAsync(_Service.Value.BaseAddressApi + "Api/Address/Create", _HttpContent);
                    return responseMessage;
                }
            }
            catch (Exception exception)
            {
                throw new Exception(string.Concat("Se presento un error al momento de enviar los datos al servidor: ", exception));
            }
        }
    }
}
