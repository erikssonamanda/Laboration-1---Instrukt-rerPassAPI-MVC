using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace InstruktorerPassMVC.Models
{
    public class RootObject
    {
        public List<InstruktorerPass> InstruktorerPass { get; set; }
    }
    public class InstruktorerPass
    {
        public int IP_Id { get; set; }
        public int IP_InstruktorId { get; set; }
        public int IP_PassId { get; set; }
    }
}
