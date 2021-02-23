using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InstruktorerPassAPI.Models;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InstruktorerPassAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PassHarInstruktorerController : ControllerBase
    {
        // GET: api/<PassHarInstruktorerController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<PassHarInstruktorerController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            List<InstruktorerPass> passHarInstruktorerList = new List<InstruktorerPass>();
            InstruktorerPassMetoder ipm = new InstruktorerPassMetoder();
            passHarInstruktorerList = ipm.GetPassetsInstruktorer(id, out string errormsg);
            string s = JsonConvert.SerializeObject(passHarInstruktorerList);
            return s;
        }

        // POST api/<PassHarInstruktorerController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<PassHarInstruktorerController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PassHarInstruktorerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
