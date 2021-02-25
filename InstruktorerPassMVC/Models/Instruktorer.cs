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

        [RegularExpression(@"^[A-Za-zåäöÅÄÖ.\s-]+$")]
        [Required(ErrorMessage = "Förnamnet måste vara en textrad med minst två bokstäver och den första bokstaven måste vara en versal!")]
        [StringLength(20, MinimumLength = 2)]
        public string In_Fornamn { get; set; }

        [RegularExpression(@"^[A-Za-zåäöÅÄÖ.\s-]+$")]
        [Required(ErrorMessage = "Efternamnet måste vara en textrad med minst två bokstäver och den första bokstaven måste vara en versal!")]
        [StringLength(40, MinimumLength = 2)]
        public string In_Efternamn { get; set; }

        [RegularExpression(@"^[A-Za-zåäöÅÄÖ0-9.\s-]+$")]
        [Required(ErrorMessage = "Adressen måste vara en textrad med minst sex bokstäver och den första bokstaven måste vara en versal!")]
        [StringLength(20, MinimumLength = 6)]
        public string In_Adress { get; set; }

        [RegularExpression(@"^[0-9]{5,5}$")]
        [Required(ErrorMessage = "Postnumret kan bara innehålla siffror")]
        public int In_Postnummer { get; set; }

        [RegularExpression(@"^[A-Za-zåäöÅÄÖ.\s]+$")]
        [Required(ErrorMessage = "Orten måste vara en textrad med minst en bokstäv och den första bokstaven måste vara en versal!")]
        [StringLength(40, MinimumLength = 1)]
        public string In_Ort { get; set; }

        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Epostadressen är inte giltig")]
        [StringLength(50, MinimumLength = 18)]
        [Required]
        public string In_Epost { get; set; }

        [RegularExpression(@"^[0-9]+$")]
        [Required(ErrorMessage = "Mobilnumret kan bara innehålla siffror")]
        [StringLength(10, MinimumLength = 10)]
        public string In_Mobil { get; set; }

        [RegularExpression(@"^[0-9]+$")]
        [Required(ErrorMessage = "Personnumret kan bara innehålla siffror")]
        [StringLength(10, MinimumLength = 10)]
        public string In_Personnummer { get; set; }
    }
}