using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SkyPioneer.Models;
using SkyPioneer.Services;

namespace SkyPioneer.Controllers
{
    
    public class AramaController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();
        private LanguageService _localization;
        public AramaController( LanguageService localization)
        {
            _localization = localization;
        }

        public ActionResult ToAirport(int id)
        {
            var datafromDatabase = context.HavaAlanlari.Where(x => x.HavaAlaniID != id).ToList();

            List<SelectListItem> selectListItems = new List<SelectListItem>();
            foreach (var item in datafromDatabase)
            {
                selectListItems.Add(new SelectListItem
                {
                    Text = item.Isim, // Göstermek istediğiniz alanın adı
                    Value = item.HavaAlaniID.ToString() // Seçilen değerin değeri
                });
            }
            return Json(selectListItems);
        }

        public ActionResult Error()
        {
            return View();
        }

        public IActionResult ChangeLanguage(string culture)
        {
            Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)), new CookieOptions()
                {
                    Expires = DateTimeOffset.UtcNow.AddYears(1)
                });
            return Redirect(Request.Headers["Referer"].ToString());
        }



        public IActionResult Index()
        {
            var datafromDatabase = context.HavaAlanlari.ToList();

            List<SelectListItem> selectListItems = new List<SelectListItem>();
            foreach (var item in datafromDatabase)
            {
                selectListItems.Add(new SelectListItem
                {
                    Text = item.Isim, // Göstermek istediğiniz alanın adı
                    Value = item.HavaAlaniID.ToString() // Seçilen değerin değeri
                });
            }




            ViewBag.From = selectListItems;
            return View();
        }

        public IActionResult Details(Arama arama)
        {
            if(ModelState.IsValid)
            {
             
               return RedirectToAction("Listele",arama);
            }
            else
                return View();
            
        }

        public IActionResult Listele(Arama arama)
        {
            var dataFromDatabase = context.Ucuslar.Where(k=>k.KalkisSaati.Day==arama.Tarih.Day).Where(k=>k.KalkisID==arama.From).Where(k => k.VarisID == arama.To).ToList();


            foreach (var item in dataFromDatabase)
            {
                item.Kalkis = context.HavaAlanlari.Where(k => k.HavaAlaniID == item.KalkisID).FirstOrDefault();
                item.Varis = context.HavaAlanlari.Where(k => k.HavaAlaniID == item.VarisID).FirstOrDefault();
                item.Ucak = context.Ucaklar.Where(k => k.UcakID == item.UcakID).FirstOrDefault();


            }

            return View(dataFromDatabase);
           
        }
    }
}
