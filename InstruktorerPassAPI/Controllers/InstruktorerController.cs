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
    public class InstruktorerController : ControllerBase
    {
        // GET: api/<InstruktorerController>
        [HttpGet]
        public string Get()
        {
            List<Instruktorer> instruktorerList = new List<Instruktorer>();
            InstruktorerPassMetoder ipm = new InstruktorerPassMetoder();
            instruktorerList = ipm.GetAllaInstruktorer(out string errormsg);
            string s = JsonConvert.SerializeObject(instruktorerList);
            return s;
        }

        // GET api/<InstruktorerController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            Instruktorer instruktorId = new Instruktorer();
            InstruktorerPassMetoder ipm = new InstruktorerPassMetoder();
            instruktorId = ipm.GetInstruktor(id, out string errormsg);
            string s = JsonConvert.SerializeObject(instruktorId);
            return s;
        }

        // POST api/<InstruktorerController>
        [HttpPost]
        public StatusCodeResult Post([FromBody] Instruktorer nyInstruktor)
        {
            InstruktorerPassMetoder ipm = new InstruktorerPassMetoder();
            ipm.PostInstruktor(nyInstruktor, out string errormsg);
            Console.WriteLine(errormsg);
            return Ok();
        }

        // PUT api/<InstruktorerController>/5
        [HttpPut("{id}")]
        public StatusCodeResult Put(int id, [FromBody] Instruktorer efternamn)
        {
            InstruktorerPassMetoder ipm = new InstruktorerPassMetoder();
            int i = ipm.PutEfternamn(id, efternamn.In_Efternamn, out string errormsg);
            if (i == 0)
            {
                return BadRequest();
            }
            else
            {
                return Ok();
            }
        }

        // DELETE api/<InstruktorerController>/5
        [HttpDelete("{id}")]
        public StatusCodeResult Delete(int id)
        {
            InstruktorerPassMetoder ipm = new InstruktorerPassMetoder();
            int i = ipm.DeleteInstruktor(id, out string errormsg);
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
