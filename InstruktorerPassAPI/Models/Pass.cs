using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InstruktorerPassAPI.Models
{
    public class Pass
    {
        [Key]
        public int Pa_Id { get; set; }
        public string Pa_Aktivitet { get; set; }
    }
}
