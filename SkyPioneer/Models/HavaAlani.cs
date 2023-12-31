using System.ComponentModel.DataAnnotations;

namespace SkyPioneer.Models
{
    public class HavaAlani
    {
        [Display(Name = "Hava Alanı ID")]
        public int HavaAlaniID { get; set; }

        [Display(Name = "Hava Alanı Kodu")]
        public string Kod { get; set; }

        [Display(Name = "Hava Alanı İsmi")]
        public string Isim { get; set; }

        [Display(Name = "Hava ALanı Ülkesi")]
        public string Ulke { get; set; }

    }
}
