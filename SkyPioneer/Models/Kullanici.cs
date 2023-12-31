using System.ComponentModel.DataAnnotations;
using System.Net.Mail;

namespace SkyPioneer.Models
{
    public class Kullanici
    {
        [Display(Name = "Kullanıcı ID")]
        public int KullaniciID { get; set; }

        [Display(Name = "Kullancı İsmi")]
        public string Isim { get; set; }

        [Display(Name = "Kullanıcı Soyismi")]
        public string SoyIsim { get; set; }

        [Display(Name = "Kullanıcı Kayıt Tarihi")]
        public DateTime KayitTarih { get; set; }

        [Display(Name = "Kullanıcı TC")]
        public string TC { get; set; }

        [Display(Name = "Kullanıcı Şifre")]
        public string Sifre { get; set; }

        [Display(Name = "Kullanıcı Mail Adresi")]
        public string MailAdres { get; set; }

        [Display(Name = "Kullanıcı Yetkisi")]
        public string Yetki { get; set; }

        
    }
}
