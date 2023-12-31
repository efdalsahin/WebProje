using System.ComponentModel.DataAnnotations;

namespace SkyPioneer.Models
{
    public class Bilet
    {
        [Display(Name = "Bilet ID")]
        public int BiletId { get; set; }

        [Display(Name = "Kullanıcı ID")]
        public int KullaniciID { get; set; }

        [Display(Name = "Kullanıcı")]
        public Kullanici Kullanici { get; set; }

        [Display(Name = "Ucuş ID")]
        public int UcusID { get; set; }

        [Display(Name = "Uçuş")]
        public Ucus Ucus { get; set; }

        [Display(Name = "Koltuk Numarası")]
        public int KoltukNo { get; set; }
    }
}
