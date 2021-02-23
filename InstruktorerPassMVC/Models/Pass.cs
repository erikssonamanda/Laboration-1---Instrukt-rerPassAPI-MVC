using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InstruktorerPassMVC.Models
{
    public class Pass
    {
        public int Pa_Id { get; set; }
        public string Pa_Aktivitet { get; set; }
    }
}
