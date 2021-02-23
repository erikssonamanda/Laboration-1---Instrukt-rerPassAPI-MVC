using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InstruktorerPassAPI.Models
{
    public class InstruktorerPass
    {
        [Key]
        public int IP_Id { get; set; }
        public int IP_InstruktorId { get; set; }
        public int IP_PassId { get; set; }
    }
}
