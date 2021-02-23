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
    public class PassController : ControllerBase
    {
        // GET: api/<PassController>
        [HttpGet]
        public string Get()
        {
            List<Pass> passList = new List<Pass>();
            InstruktorerPassMetoder ipm = new InstruktorerPassMetoder();
            passList = ipm.GetAllaPass(out string errormsg);
            string s = JsonConvert.SerializeObject(passList);
            return s;
        }

        // GET api/<PassController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            Pass passId = new Pass();
            InstruktorerPassMetoder ipm = new InstruktorerPassMetoder();
            passId = ipm.GetPass(id, out string errormsg);
            string s = JsonConvert.SerializeObject(passId);
            return s;
        }

        // POST api/<PassController>
        [HttpPost]
        public StatusCodeResult PostPass([FromBody] Pass nyttPass)
        {
            InstruktorerPassMetoder ipm = new InstruktorerPassMetoder();
            ipm.PostPass(nyttPass, out string errormsg);
            Console.WriteLine(errormsg);
            return Ok();
        }

        // PUT api/<PassController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PassController>/5
        [HttpDelete("{id}")]
        public StatusCodeResult Delete(int id)
        {
            InstruktorerPassMetoder ipm = new InstruktorerPassMetoder();
            int i = ipm.DeletePass(id, out string errormsg);
            Console.WriteLine(errormsg);
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
