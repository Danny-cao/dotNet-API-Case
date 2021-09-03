using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APICase.Models
{
    public class AdresDTO
    {
        [Required]
        public string Huisnummer { get; set; }
        [Required]
        public string Straat { get; set; }
        [Required]
        public string Plaats { get; set; }
    }
}
