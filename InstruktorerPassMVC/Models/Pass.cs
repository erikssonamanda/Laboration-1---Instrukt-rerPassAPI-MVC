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

        [RegularExpression(@"^[A-Za-zåäöÅÄÖ0-9.\s]+$")]
        [Required(ErrorMessage = "Aktiviteten måste vara en textrad och den första bokstaven måste vara en versal!")]
        [StringLength(20)]
        public string Pa_Aktivitet { get; set; }
    }
}
