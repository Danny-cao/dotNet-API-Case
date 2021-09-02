using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace APICase.DAL.Models
{
    public class Adres
    {
        [Key]
        public long Id { get; set; }
        public string Straat { get; set; }
        public string Huisnummer { get; set; }
        public string PostCode { get; set; }
        public string Plaats { get; set; }
        public string Land { get; set; }
    }
}
