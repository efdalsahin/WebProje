using System.ComponentModel.DataAnnotations;

namespace SkyPioneer.Models
{
    public class Ucus
    {
        [Display(Name = "Uçuş ID")]
        public int UcusID { get; set; }

        [Display(Name = "Uçuş Kalkış Saati")]
        public DateTime KalkisSaati { get; set; }

        [Display(Name = "Kalkış Yeri")]
        public int KalkisID { get; set; }

        [Display(Name = "Kalkış Yeri")]
        public HavaAlani Kalkis { get; set; }

        [Display(Name = "Varış Yeri")]
        public int VarisID { get; set; }

        [Display(Name = "Varış Yeri")]
        public HavaAlani Varis { get; set; }

        [Display(Name = "Uçuş Fiyatı")]
        public int Fiyat { get; set; }

        [Display(Name = "Uçak ID")]
        public int UcakID { get; set; }

        [Display(Name = "Uçak ID")]
        public Ucak Ucak { get; set; }
    }
}
