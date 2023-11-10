using System.Net.Mail;

namespace SkyPioneer.Models
{
    public class Kullanici
    {
        public int KullaniciID { get; set; }
        public string Isim { get; set; }
        public string SoyIsim { get; set; }
        public DateTime KayitTarih { get; set; }
        public string TC { get; set; }
        public string Sifre { get; set; }
        public string MailAdres { get; set; }
        public string Yetki { get; set; }

        
    }
}
