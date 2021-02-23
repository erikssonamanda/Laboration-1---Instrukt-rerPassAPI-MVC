using InstruktorerPassMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using InstruktorerPassMVC.Helper;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net.Http.Json;
using InstruktorerPassMVC.Data;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;

namespace InstruktorerPassMVC.Controllers
{
    public class HomeController : Controller
    {
        InstruktorerPassAPI api = new InstruktorerPassAPI(); 

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        /* Metod: 
         * Beskrivning: 
         * Returnerar: 
        */
        public async Task<IActionResult> ReadAllaInstruktorer()
        {
            List<Instruktorer> instruktorer = new List<Instruktorer>();
            HttpClient client = api.Initial();
            HttpResponseMessage response = await client.GetAsync("api/Instruktorer"); 
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                instruktorer = JsonConvert.DeserializeObject<List<Instruktorer>>(result); 
            }
            return View(instruktorer);
        }

        public async Task<IActionResult> ReadInstruktor(int id)
        {
            if(id == 0)
            {
                return NotFound(); 
            }

            Instruktorer instruktor = new Instruktorer();
            HttpClient client = api.Initial();
            HttpResponseMessage response = await client.GetAsync("api/Instruktorer/" + id);

            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                instruktor = JsonConvert.DeserializeObject<Instruktorer>(result);
            }
            return View(instruktor);

        }

        public async Task<IActionResult> ReadAllaPass()
        {
            List<Pass> pass = new List<Pass>();
            HttpClient client = api.Initial();
            HttpResponseMessage response = await client.GetAsync("api/Pass");
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                pass = JsonConvert.DeserializeObject<List<Pass>>(result); 
            }
            return View(pass); 
        }

        public async Task<IActionResult> ReadPass(int id)
        {
            if(id == 0)
            {
                return NotFound();
            }

            Pass pass = new Pass();
            HttpClient client = api.Initial();
            HttpResponseMessage response = await client.GetAsync("api/Pass/" + id);

            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                pass = JsonConvert.DeserializeObject<Pass>(result);
            }
            return View(pass); 
        }

        public async Task<IActionResult> ReadAllaInstruktorerHarPass()
        {
            List<InstruktorerPass> instruktorerPass = new List<InstruktorerPass>();
            HttpClient client = api.Initial();
            HttpResponseMessage response = await client.GetAsync("api/InstruktorerPass");
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                instruktorerPass = JsonConvert.DeserializeObject<List<InstruktorerPass>>(result); 
            }
            return View(instruktorerPass); 
        }

        public async Task<IActionResult> ReadInstruktorensPass(int id)
        {
            if(id == 0)
            {
                return NotFound(); 
            }

            List<InstruktorerPass> instruktorensPass = new List<InstruktorerPass>();
            HttpClient client = api.Initial();
            HttpResponseMessage response = await client.GetAsync("api/InstruktorerPass/" + id);

            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result; 
                instruktorensPass = JsonConvert.DeserializeObject<List<InstruktorerPass>>(result); 
            }
            return View(instruktorensPass);
        }

        public async Task<IActionResult> ReadInstruktorensPassDetalj(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            InstruktorerPass instruktorensPassDetalj = new InstruktorerPass();
            HttpClient client = api.Initial();
            HttpResponseMessage response = await client.GetAsync("api/InstruktorerPassDetalj/" + id);

            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                instruktorensPassDetalj = JsonConvert.DeserializeObject<InstruktorerPass>(result);
            }
            return View(instruktorensPassDetalj);
        }

        public async Task<IActionResult> ReadPassetHarInstruktorer(int id)
        {
            if(id == 0)
            {
                return NotFound(); 
            }

            List<InstruktorerPass> passetsInstruktorer = new List<InstruktorerPass>();
            HttpClient client = api.Initial();
            HttpResponseMessage response = await client.GetAsync("api/PassHarInstruktorer/" + id);

            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                passetsInstruktorer = JsonConvert.DeserializeObject<List<InstruktorerPass>>(result); 
            }
            return View(passetsInstruktorer);
        }

        public ActionResult CreateInstruktor()
        {
            return View(); 
        }

        [HttpPost]
        public async Task<ActionResult> CreateInstruktor(Instruktorer nyInstruktor)
        {
            if (ModelState.IsValid)
            {
                HttpClient client = api.Initial();
                HttpResponseMessage response = await client.PostAsJsonAsync("api/Instruktorer", nyInstruktor);
                response.EnsureSuccessStatusCode(); 
                return RedirectToAction("ReadAllaInstruktorer");
            }
            else
            {
                return View(nyInstruktor);
            }
        }

        public ActionResult CreatePass()
        {
            return View(); 
        }

        [HttpPost]
        public async Task<ActionResult> CreatePass(Pass nyttPass)
        {
            if (ModelState.IsValid)
            {
                HttpClient client = api.Initial();
                HttpResponseMessage response = await client.PostAsJsonAsync("api/Pass", nyttPass);
                response.EnsureSuccessStatusCode();
                return RedirectToAction("ReadAllaPass"); 
            }
            else
            {
                return View(nyttPass);
            }
        }

        public ActionResult CreateInstruktorHarPass()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> CreateInstruktorHarPass(InstruktorerPass tilldelaPass)
        {
            if (ModelState.IsValid)
            {
                HttpClient client = api.Initial();
                HttpResponseMessage response = await client.PostAsJsonAsync("api/InstruktorerPass", tilldelaPass);
                response.EnsureSuccessStatusCode();
                return RedirectToAction("ReadAllaInstruktorerHarPass");
            }
            else
            {
                return View("tilldelaPass");
            }
        }

        public ActionResult UpdateEfternamn()
        {
            return View(); 
        }

        [HttpPost]
        public async Task<ActionResult> UpdateEfternamn(int id, Instruktorer efternamn)
        {
            if (ModelState.IsValid)
            {
                HttpClient client = api.Initial();
                HttpResponseMessage response = await client.PutAsJsonAsync("api/Instruktorer/" + id, efternamn);
                response.EnsureSuccessStatusCode();
                return RedirectToAction("ReadAllaInstruktorer");
            }
            else
            {
                return View(efternamn);
            }
        }

        public ActionResult UpdateAdress()
        {
            return View(); 
        }

        [HttpPost]
        public async Task<ActionResult> UpdateAdress(int id, Instruktorer adress)
        {
            if (ModelState.IsValid)
            {
                HttpClient client = api.Initial();
                HttpResponseMessage response = await client.PutAsJsonAsync("api/Adress/" + id, adress);
                response.EnsureSuccessStatusCode();
                return RedirectToAction("ReadAllaInstruktorer");
            }
            else
            {
                return View(adress);
            }
        }

        public ActionResult UpdateEpost()
        {
            return View(); 
        }

        [HttpPost]
        public async Task<ActionResult> UpdateEpost(int id, Instruktorer epost)
        {
            if (ModelState.IsValid)
            {
                HttpClient client = api.Initial();
                HttpResponseMessage response = await client.PutAsJsonAsync("api/Epost/" + id, epost);
                response.EnsureSuccessStatusCode();
                return RedirectToAction("ReadAllaInstruktorer");
            }
            else
            {
                return View(epost);
            }
        }

        public ActionResult UpdateMobil()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> UpdateMobil(int id, Instruktorer mobil)
        {
            if (ModelState.IsValid)
            {
                HttpClient client = api.Initial();
                HttpResponseMessage response = await client.PutAsJsonAsync("api/Mobil/" + id, mobil);
                response.EnsureSuccessStatusCode();
                return RedirectToAction("ReadAllaInstruktorer");
            }
            else
            {
                return View(mobil);
            }
        }

        public async Task<ActionResult> DeleteInstruktor(int id)
        {
            if(id == 0)
            {
                return NotFound();
            }

            Instruktorer instruktor = new Instruktorer();
            HttpClient client = api.Initial();
            HttpResponseMessage response = await client.GetAsync("api/Instruktorer/" + id);

            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                instruktor = JsonConvert.DeserializeObject<Instruktorer>(result);
            }
            return View(instruktor); 
        }

        [HttpPost, ActionName("DeleteInstruktor")]
        public async Task<ActionResult> DeleteInstruktorConfirmed(int id)
        {
            Instruktorer instruktor = new Instruktorer();
            HttpClient client = api.Initial();
            HttpResponseMessage response = await client.DeleteAsync("api/Instruktorer/" + id);
            return RedirectToAction("ReadAllaInstruktorer"); 
        }

        public async Task<ActionResult> DeletePass(int id)
        {
            if(id == 0)
            {
                return NotFound();
            }

            Pass pass = new Pass();
            HttpClient client = api.Initial();
            HttpResponseMessage response = await client.GetAsync("api/Pass/" + id);

            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                pass = JsonConvert.DeserializeObject<Pass>(result);
            }
            return View(pass);
        }

        [HttpPost, ActionName("DeletePass")]
        public async Task<ActionResult> DeletePassConfirmed(int id)
        {
            Pass pass = new Pass();
            HttpClient client = api.Initial();
            HttpResponseMessage response = await client.DeleteAsync("api/Pass/" + id);
            return RedirectToAction("ReadAllaPass"); 
        }

        public async Task<ActionResult> DeleteInstruktorHarPass(int id)
        {
            if(id == 0)
            {
                return NotFound();
            }

            InstruktorerPass instruktorHarPass = new InstruktorerPass();
            HttpClient client = api.Initial();
            HttpResponseMessage response = await client.GetAsync("api/InstruktorerPassDetalj/" + id);

            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                instruktorHarPass = JsonConvert.DeserializeObject<InstruktorerPass>(result); 
            }
            return View(instruktorHarPass);
        }

        [HttpPost, ActionName("DeleteInstruktorHarPass")]
        public async Task<ActionResult> DeleteInstruktorHarPassConfirmed(int id)
        {
            InstruktorerPass instruktorHarPass = new InstruktorerPass();
            HttpClient client = api.Initial();
            HttpResponseMessage response = await client.DeleteAsync("api/InstruktorerPassDetalj/" + id);
            return RedirectToAction("ReadAllaInstruktorerHarPass"); 
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
