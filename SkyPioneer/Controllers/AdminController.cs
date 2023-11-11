using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SkyPioneer.Models;
using System.Net.Http;

namespace SkyPioneer.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AdminController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> UcuslarDetails()
        {
            //var dataFromDatabase=context.Ucuslar.ToList();


            //foreach (var item in dataFromDatabase)
            //{
            //    item.Kalkis = context.HavaAlanlari.Where(k => k.HavaAlaniID == item.KalkisID).FirstOrDefault();
            //    item.Varis = context.HavaAlanlari.Where(k => k.HavaAlaniID == item.VarisID).FirstOrDefault();
            //    item.Ucak=context.Ucaklar.Where(k => k.UcakID == item.UcakID).FirstOrDefault();   


            //}

            // HttpClient oluştur
            using (var httpClient = new HttpClient())
            {
                // API'nin URL'si
                var apiUrl = "https://localhost:7045/api/SkyPioneerApi/";

                try
                {
                    // GET isteği
                    var response = await httpClient.GetAsync(apiUrl);

                    // Başarı durumu kontrolü
                    if (response.IsSuccessStatusCode)
                    {
                        // Başarılı bir şekilde cevap alındı
                        var responseData = await response.Content.ReadAsStringAsync();
                        // responseData içinde API'nin cevabını kullanabilirsiniz
                        // ...
                        var ucuslar=JsonConvert.DeserializeObject<List<Ucus>>(responseData);
                        return View(ucuslar);
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

            return View();
        }
        public IActionResult HavaAlanlariDetails()
        {
            var dataFromDatabase=context.HavaAlanlari.ToList();

            return View(dataFromDatabase);
        }

        public IActionResult HavaYollariDetails()
        {
            var dataFromDatabase = context.HavaYollari.ToList();

            return View(dataFromDatabase);
        }

        public IActionResult UcaklarDetails()
        {
            var dataFromDatabase = context.Ucaklar.ToList();

            foreach (var item in dataFromDatabase)
            {
                item.HavaYolu = context.HavaYollari.Where(k => k.HavaYoluID == item.HavaYoluID).FirstOrDefault();
               


            }

            return View(dataFromDatabase);
        }

        public IActionResult KullanicilarDetails()
        {
            var dataFromDatabase = context.Kullancilar.ToList();

            return View(dataFromDatabase);
        }


    }
}
