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
    public class PhoneController : Controller
    {
        private readonly IOptions<ConfigurationManager> _Service;

        public PhoneController(IOptions<ConfigurationManager> pConfiguration)
        {
            _Service = pConfiguration;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<Phone>> GetAll()
        {
            try
            {
                List<Phone> lstPhone = new();
                using (HttpClient _HttpClient = new())
                {
                    HttpResponseMessage responseMessage = await _HttpClient.GetAsync(_Service.Value.BaseAddressApi + "Api/Phone/GetAll");
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        lstPhone = JsonConvert.DeserializeObject<List<Phone>>(await responseMessage.Content.ReadAsStringAsync());
                    }
                }
                return lstPhone;
            }
            catch (Exception exception)
            {
                throw new Exception(string.Concat("Error del servidor: ", exception.Message), exception);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pId"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<Phone>> GetByIdPerson(int pIdPerson)
        {
            try
            {
                List<Phone> lstPhone = new();
                using (HttpClient _HttpClient = new())
                {
                    HttpResponseMessage responseMessage = await _HttpClient.GetAsync(_Service.Value.BaseAddressApi + "Api/Phone/GetByIdPerson?pIdPerson=" + pIdPerson);
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        lstPhone = JsonConvert.DeserializeObject<List<Phone>>(await responseMessage.Content.ReadAsStringAsync());
                    }
                }
                return lstPhone;
            }
            catch (Exception exception)
            {
                throw new Exception(string.Concat("Error del servidor: ", exception.Message), exception);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pPhone"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<HttpResponseMessage> Update([FromBody] Phone pPhone)
        {
            try
            {
                using (HttpClient _HttpClient = new())
                {
                    string strPhone = JsonConvert.SerializeObject(pPhone);
                    HttpContent _HttpContent = new StringContent(strPhone, Encoding.UTF8, "application/json");
                    HttpResponseMessage responseMessage = await _HttpClient.PutAsync(_Service.Value.BaseAddressApi + "Api/Phone/Update", _HttpContent);
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
                    HttpResponseMessage responseMessage = await _HttpClient.DeleteAsync(_Service.Value.BaseAddressApi + "Api/Phone/Delete?pId=" + pId);
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
        /// <param name="pPhone"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<HttpResponseMessage> Create([FromBody] Phone pPhone)
        {
            try
            {
                using (HttpClient _HttpClient = new())
                {
                    string strPhone = JsonConvert.SerializeObject(pPhone);
                    HttpContent _HttpContent = new StringContent(strPhone, Encoding.UTF8, "application/json");
                    HttpResponseMessage responseMessage = await _HttpClient.PostAsync(_Service.Value.BaseAddressApi + "Api/Phone/Create", _HttpContent);
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
