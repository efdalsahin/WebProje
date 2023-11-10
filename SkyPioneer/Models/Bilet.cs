namespace SkyPioneer.Models
{
    public class Bilet
    {
        public int BiletId { get; set; }

        public int KullaniciID { get; set; }
        public Kullanici Kullanici { get; set; }

        public int UcusID { get; set; }

        public Ucus Ucus { get; set; }

        public int KoltukNo { get; set; }
    }
}
