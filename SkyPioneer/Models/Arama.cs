using System.ComponentModel.DataAnnotations;

namespace SkyPioneer.Models
{
    public class Arama
    {
        [Display(Name ="Nereden")]
        public int From { get; set; }
        [Display(Name = "Nereye")]
        public int To { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Tarih")]
        public DateTime Tarih { get; set; }

    }
}
