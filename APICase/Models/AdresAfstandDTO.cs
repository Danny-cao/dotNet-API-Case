using System.ComponentModel.DataAnnotations;

namespace APICase.Models
{
    public class AdresAfstandDTO
    {
        [Required]
        public AdresDTO adres1 { get; set; }
        [Required]
        public AdresDTO adres2 { get; set; }
    }
}
