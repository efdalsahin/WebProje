namespace SkyPioneer.Models
{
    public class HavaYolu
    {
        public int HavaYoluID { get; set; }
        public string Isim { get; set; }
        public string Ulke { get; set; }


        // Hava yolu şirketinin uçakları
        public ICollection<Ucak> ?Ucaklar { get; set; }
    }
}
