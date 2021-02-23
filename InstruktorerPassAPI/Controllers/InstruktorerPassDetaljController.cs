using InstruktorerPassAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InstruktorerPassAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstruktorerPassDetaljController : ControllerBase
    {
        // GET: api/<InstruktorerPassDetaljController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<InstruktorerPassDetaljController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            InstruktorerPass instruktorPassList = new InstruktorerPass();
            InstruktorerPassMetoder ipm = new InstruktorerPassMetoder();
            instruktorPassList = ipm.GetInstruktorensPassDetalj(id, out string errormsg);
            string s = JsonConvert.SerializeObject(instruktorPassList);
            return s;
        }

        // POST api/<InstruktorerPassDetaljController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<InstruktorerPassDetaljController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<InstruktorerPassDetaljController>/5
        [HttpDelete("{id}")]
        public StatusCodeResult Delete(int id)
        {
            InstruktorerPassMetoder ipm = new InstruktorerPassMetoder();
            int i = ipm.DeleteInstruktorHarPass(id, out string errormsg);
            if (i == 0)
            {
                return BadRequest();
            }
            else
            {
                return Ok();
            }
        }
    }
}
