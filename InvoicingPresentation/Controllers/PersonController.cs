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
    public class PersonController : Controller
    {
        private readonly IOptions<ConfigurationManager> _Service;

        public PersonController(IOptions<ConfigurationManager> pConfiguration)
        {
            _Service = pConfiguration;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<Person>> GetAll()
        {
            try
            {
                List<Person> lstPerson = new();
                using (HttpClient _HttpClient = new())
                {
                    HttpResponseMessage responseMessage = await _HttpClient.GetAsync(_Service.Value.BaseAddressApi + "Api/Person/GetAll");
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        lstPerson = JsonConvert.DeserializeObject<List<Person>>(await responseMessage.Content.ReadAsStringAsync());
                    }
                }
                return lstPerson;
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
        public async Task<Person> GetById(int pId)
        {
            try
            {
                Person objPerson = new();
                using (HttpClient _HttpClient = new())
                {
                    HttpResponseMessage responseMessage = await _HttpClient.GetAsync(_Service.Value.BaseAddressApi + "Api/Person/GetById?pId=" + pId);
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        objPerson = JsonConvert.DeserializeObject<Person>(await responseMessage.Content.ReadAsStringAsync());
                    }
                }
                return objPerson;
            }
            catch (Exception exception)
            {
                throw new Exception(string.Concat("Error del servidor: ", exception.Message), exception);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pPerson"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<HttpResponseMessage> Update([FromBody] Person pPerson)
        {
            try
            {
                using (HttpClient _HttpClient = new())
                {
                    string strPerson = JsonConvert.SerializeObject(pPerson);
                    HttpContent _HttpContent = new StringContent(strPerson, Encoding.UTF8, "application/json");
                    HttpResponseMessage responseMessage = await _HttpClient.PutAsync(_Service.Value.BaseAddressApi + "Api/Person/Update", _HttpContent);
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
                    HttpResponseMessage responseMessage = await _HttpClient.DeleteAsync(_Service.Value.BaseAddressApi + "Api/Person/Delete?pId=" + pId);
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
        /// <param name="pPerson"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<HttpResponseMessage> Create([FromBody] Person pPerson)
        {
            try
            {
                using (HttpClient _HttpClient = new())
                {
                    string strPerson = JsonConvert.SerializeObject(pPerson);
                    HttpContent _HttpContent = new StringContent(strPerson, Encoding.UTF8, "application/json");
                    HttpResponseMessage responseMessage = await _HttpClient.PostAsync(_Service.Value.BaseAddressApi + "Api/Person/Create", _HttpContent);
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
