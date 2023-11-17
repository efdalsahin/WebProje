using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Newtonsoft.Json;
using SkyPioneer.Models;
using System.Security.Claims;

namespace SkyPioneer.Controllers
{
    public class KullaniciController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Kayit()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Kayit(Kullanici kullanici)
        {
            ModelState.Remove("Yetki");
            kullanici.KayitTarih=DateTime.Now;
            kullanici.Yetki = "Kullanici";

            if(ModelState.IsValid)
            {
                context.Kullancilar.Add(kullanici);
                context.SaveChanges();
                TempData["msj"] = kullanici.Isim + " adlı kullanıcı kayıt edildi";
                return RedirectToAction("Index","Arama");
            }
            
            return View();
        }

        public IActionResult Giris()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Giris(Kullanici kullanici)
        {
            ModelState.Remove("KullaniciID");
            ModelState.Remove("Isim");
            ModelState.Remove("SoyIsim");
            ModelState.Remove("KayitTarih");
            ModelState.Remove("TC");
            ModelState.Remove("Yetki");

            var datafromdatabase=context.Kullancilar.Where(k=>k.MailAdres==kullanici.MailAdres && k.Sifre==kullanici.Sifre).FirstOrDefault();
            var isAdmin = (datafromdatabase.Yetki == "Admin");
            if (datafromdatabase == null)
            {
                TempData["msj"] = "Giris bilgileri hatalıdır.";
                return RedirectToAction("Giris");
            }

            if(ModelState.IsValid)
            {
                List<Claim> claims ;
                if (isAdmin)
                {
                    claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Role,"Admin"),
                        new Claim(ClaimTypes.NameIdentifier,datafromdatabase.KullaniciID.ToString())
                        
                    };
                }
                else
                {
                    claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Role,"Kullanici"),
                        new Claim(ClaimTypes.NameIdentifier,datafromdatabase.KullaniciID.ToString())

                    };

                }

                var claimsidentity=new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);
                var authproperties = new AuthenticationProperties { };

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsidentity), authproperties);

                return RedirectToAction("Index", "Arama");

            }
            return View("Giris");

        }

        public async Task<IActionResult> cikisYap()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Giris");
        }

        public IActionResult HesapDuzenle()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> HesapDuzenle(Kullanici kullanici)
        {
            ModelState.Remove("KullaniciID");
            ModelState.Remove("Isim");
            ModelState.Remove("SoyIsim");
            ModelState.Remove("KayitTarih");
            ModelState.Remove("TC");
            ModelState.Remove("Yetki");
            ModelState.Remove("MailAdres");


            if (ModelState.IsValid)
            {
                using (var httpClient = new HttpClient())
                {
                    // API'nin URL'si
                    var apiUrl = "https://localhost:7045/api/SkyPioneerApi/hesapguncelle/"+int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value)+"/"+kullanici.Sifre;

                    try
                    {
                        // GET isteği
                        var response = await httpClient.GetAsync(apiUrl);

                        // Başarı durumu kontrolü
                        if (response.IsSuccessStatusCode)
                        {
                            var responseData = await response.Content.ReadAsStringAsync();


                            // Başarılı bir şekilde cevap alındı
                            TempData["msj"] = responseData;
                            return View();
                        }
                        else
                        {
                            // Başarısız durumda
                            // response.StatusCode ve response.ReasonPhrase gibi bilgileri kontrol edebilirsiniz
                            // ...
                            return View("ErrorView");
                        }
                    }
                    catch (HttpRequestException ex)
                    {
                        // İstek sırasında hata oluştu
                        // ex.Message gibi hata bilgilerini kontrol edebilirsiniz
                        // ...
                        return View("ErrorView");
                    }
                }
                return View("ErrorView");

                //var datafromdatabase = context.Kullancilar.Where(k => k.MailAdres == kullanici.MailAdres && k.Sifre == kullanici.Sifre).FirstOrDefault();
                //datafromdatabase.Sifre= kullanici.Sifre;
                //context.SaveChanges();


            }
            return View("ErrorView");


        }

        public IActionResult KullaniciDetails()
        {
            int id = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            var datafromdatabase = context.Kullancilar.Where(k => k.KullaniciID == id).FirstOrDefault();
            return View(datafromdatabase);
        }
        public IActionResult KullaniciDetailss(int id)
        {
           
            var datafromdatabase = context.Kullancilar.Where(k => k.KullaniciID == id).FirstOrDefault();
            return View(datafromdatabase);
        }
    }
}
