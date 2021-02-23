using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InstruktorerPassAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InstruktorerPassAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EpostController : ControllerBase
    {
        // GET: api/<EpostController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<EpostController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<EpostController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<EpostController>/5
        [HttpPut("{id}")]
        public StatusCodeResult Put(int id, [FromBody] Instruktorer epost)
        {
            InstruktorerPassMetoder ipm = new InstruktorerPassMetoder();
            int i = ipm.PutEpost(id, epost.In_Epost, out string errormsg); 
            if(i == 0)
            {
                return BadRequest();
            }
            else
            {
                return Ok(); 
            }
        }

        // DELETE api/<EpostController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
