using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace InstruktorerPassMVC.Models
{
    public class InstruktorerPass
    {
        public int IP_Id { get; set; }

        [RegularExpression(@"^[0-9]{1,}$")]
        [Required(ErrorMessage = "Instruktörens id kan bara innehålla siffror")]
        public int IP_InstruktorId { get; set; }

        [RegularExpression(@"^[0-9]{1,}$")]
        [Required(ErrorMessage = "Aktivitetens id kan bara innehålla siffror")]
        public int IP_PassId { get; set; }
    }
}

