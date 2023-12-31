using System.ComponentModel.DataAnnotations;

namespace SkyPioneer.Models
{
    public class Ucak
    {
        [Display(Name = "Uçak ID")]
        public int UcakID { get; set; }

        [Display(Name = "Uçak Modeli")]
        public string Modell { get; set; }

        [Display(Name = "Uçak Kapasitesi")]
        public int Kapasite { get; set; }

        [Display(Name = "Hava Yolu ID")]
        // Uçağın bağlı olduğu hava yolu şirketi
        public int HavaYoluID { get; set; }
        public HavaYolu HavaYolu { get; set; }
    }
}
