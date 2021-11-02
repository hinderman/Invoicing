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
    public class EmailController : Controller
    {
        private readonly IOptions<ConfigurationManager> _Service;

        public EmailController(IOptions<ConfigurationManager> pConfiguration)
        {
            _Service = pConfiguration;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<Email>> GetAll()
        {
            try
            {
                List<Email> lstEmail = new();
                using (HttpClient _HttpClient = new())
                {
                    HttpResponseMessage responseMessage = await _HttpClient.GetAsync(_Service.Value.BaseAddressApi + "Api/Email/GetAll");
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        lstEmail = JsonConvert.DeserializeObject<List<Email>>(await responseMessage.Content.ReadAsStringAsync());
                    }
                }
                return lstEmail;
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
        public async Task<IEnumerable<Email>> GetByIdPerson(int pIdPerson)
        {
            try
            {
                List<Email> lstEmail = new();
                using (HttpClient _HttpClient = new())
                {
                    HttpResponseMessage responseMessage = await _HttpClient.GetAsync(_Service.Value.BaseAddressApi + "Api/Email/GetByIdPerson?pIdPerson=" + pIdPerson);
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        lstEmail = JsonConvert.DeserializeObject<List<Email>>(await responseMessage.Content.ReadAsStringAsync());
                    }
                }
                return lstEmail;
            }
            catch (Exception exception)
            {
                throw new Exception(string.Concat("Error del servidor: ", exception.Message), exception);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pEmail"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<HttpResponseMessage> Update([FromBody] Email pEmail)
        {
            try
            {
                using (HttpClient _HttpClient = new())
                {
                    string strEmail = JsonConvert.SerializeObject(pEmail);
                    HttpContent _HttpContent = new StringContent(strEmail, Encoding.UTF8, "application/json");
                    HttpResponseMessage responseMessage = await _HttpClient.PutAsync(_Service.Value.BaseAddressApi + "Api/Email/Update", _HttpContent);
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
                    HttpResponseMessage responseMessage = await _HttpClient.DeleteAsync(_Service.Value.BaseAddressApi + "Api/Email/Delete?pId=" + pId);
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
        /// <param name="pEmail"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<HttpResponseMessage> Create([FromBody] Email pEmail)
        {
            try
            {
                using (HttpClient _HttpClient = new())
                {
                    string strEmail = JsonConvert.SerializeObject(pEmail);
                    HttpContent _HttpContent = new StringContent(strEmail, Encoding.UTF8, "application/json");
                    HttpResponseMessage responseMessage = await _HttpClient.PostAsync(_Service.Value.BaseAddressApi + "Api/Email/Create", _HttpContent);
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
