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
    public class InstruktorerPassController : ControllerBase
    {
        // GET: api/<InstruktorerPassController>
        [HttpGet]
        public string Get()
        {
            List<InstruktorerPass> instruktorerPassList = new List<InstruktorerPass>();
            InstruktorerPassMetoder ipm = new InstruktorerPassMetoder();
            instruktorerPassList = ipm.GetInstruktorerHarPass(out string errormsg);
            string s = JsonConvert.SerializeObject(instruktorerPassList);
            return s;
        }

        // GET api/<InstruktorerPassController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            List<InstruktorerPass> instruktorPassList = new List<InstruktorerPass>();
            InstruktorerPassMetoder ipm = new InstruktorerPassMetoder();
            instruktorPassList = ipm.GetInstruktorensPass(id, out string errormsg);
            string s = JsonConvert.SerializeObject(instruktorPassList);
            return s;
        }

        // POST api/<InstruktorerPassController>
        [HttpPost]
        public StatusCodeResult Post([FromBody] InstruktorerPass nyttPassTillInstruktor)
        {
            InstruktorerPassMetoder ipm = new InstruktorerPassMetoder();
            ipm.PostInstruktorHarPass(nyttPassTillInstruktor, out string errormsg);
            Console.WriteLine(errormsg);
            return Ok();
        }

        // PUT api/<InstruktorerPassController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<InstruktorerPassController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
