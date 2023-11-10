namespace SkyPioneer.Models
{
    public class Ucak
    {
        public int UcakID { get; set; }
        public string Modell { get; set; }
        public int Kapasite { get; set; }


        // Uçağın bağlı olduğu hava yolu şirketi
        public int HavaYoluID { get; set; }
        public HavaYolu HavaYolu { get; set; }
    }
}
