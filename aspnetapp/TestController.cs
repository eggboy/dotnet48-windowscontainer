using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Web.Http;

namespace aspnetapp
{
    public class TestController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            var builder = new StringBuilder(Environment.NewLine);

            foreach (var header in Request.Headers)
                builder.AppendLine(header.Key + "=" + String.Join(", ", header.Value));

            if (id == 1)
            {
        
                for(int i = 0; i < 10; i++)
                {
                    Console.Out.WriteLine("Liveness Probe " + i + " sec");
                    Thread.Sleep(1000);
                }
                return "Liveness";
            }
            else if(id == 2)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return builder.ToString();
        }

        // POST api/<controller>
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}
