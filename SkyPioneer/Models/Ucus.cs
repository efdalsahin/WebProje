namespace SkyPioneer.Models
{
    public class Ucus
    {
        public int UcusID { get; set; }
        public DateTime KalkisSaati { get; set; }
        public int KalkisID { get; set; }
        public HavaAlani Kalkis { get; set; }
        public int VarisID { get; set; }
        public HavaAlani Varis { get; set; }
        public int Fiyat { get; set; }
        public int UcakID { get; set; }
        public Ucak Ucak { get; set; }
    }
}
