using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InstruktorerPassMVC.Models
{
    public class Instruktorer
    {
        public int In_Id { get; set; }
        public string In_Fornamn { get; set; }
        public string In_Efternamn { get; set; }
        public string In_Adress { get; set; }
        public int In_Postnummer { get; set; }
        public string In_Ort { get; set; }
        public string In_Epost { get; set; }
        public string In_Mobil { get; set; }
        public string In_Personnummer { get; set; }
    }
}