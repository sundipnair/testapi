using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TestApi.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private string testapi2 = "http://testapi2:80/";

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            List<string> list = GetDataAsync().Result.ToList();
            list.Add("harry");
            return list;
        }

        private async Task<IEnumerable<string>> GetDataAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync($"{testapi2}api/values");
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsAsync<IEnumerable<string>>();
            }
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = client.GetAsync($"{testapi2}api/values/{id}").Result;
                response.EnsureSuccessStatusCode();
                return response.Content.ReadAsAsync<string>().Result;
            }
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = client.PostAsync($"{testapi2}api/values", new StreamContent(Request.Body)).Result;
                response.EnsureSuccessStatusCode();
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = client.PostAsync($"{testapi2}api/values/{id}", new StreamContent(Request.Body)).Result;
                response.EnsureSuccessStatusCode();
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = client.DeleteAsync($"{testapi2}api/values/{id}").Result;
                response.EnsureSuccessStatusCode();
            }
        }
    }
}
