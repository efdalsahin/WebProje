using System.ComponentModel.DataAnnotations;

namespace SkyPioneer.Models
{
    public class HavaYolu
    {
        [Display(Name = "Hava Yolu ID")]
        public int HavaYoluID { get; set; }

        [Display(Name = "Hava Yolu İsmi")]
        public string Isim { get; set; }

        [Display(Name = "Hava Yolu Ülkesi")]
        public string Ulke { get; set; }


        // Hava yolu şirketinin uçakları
        public ICollection<Ucak> ?Ucaklar { get; set; }
    }
}
