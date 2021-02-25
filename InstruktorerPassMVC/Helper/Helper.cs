using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace InstruktorerPassMVC.Helper
{
   public class InstruktorerPassAPI
   {
        public HttpClient Initial()
        {
            var Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:52228");
            return Client; 
        }
   }
}
