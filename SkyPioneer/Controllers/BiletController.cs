using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SkyPioneer.Models;
using System.Net;
using System.Security.Claims;

namespace SkyPioneer.Controllers
{
    [Authorize(Roles = "Admin,Kullanici")]
    public class BiletController : Controller
    {

        ApplicationDbContext context=new ApplicationDbContext();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SatinAl(int id)
        {
            var datafromdatabase=context.Ucuslar.Where(k=>k.UcusID==id).FirstOrDefault();

            List<int> alinmiskoltuklar = new List<int>();

            var biletler=context.Biletler.Where(k=>k.UcusID==id).ToList();

            foreach(var item in biletler)
            {
                alinmiskoltuklar.Add(item.KoltukNo);
            }
            datafromdatabase.Kalkis = context.HavaAlanlari.Where(k => k.HavaAlaniID == datafromdatabase.KalkisID).FirstOrDefault();
            datafromdatabase.Varis = context.HavaAlanlari.Where(k => k.HavaAlaniID == datafromdatabase.VarisID).FirstOrDefault();
            datafromdatabase.Ucak = context.Ucaklar.Where(k => k.UcakID == datafromdatabase.UcakID).FirstOrDefault();
            datafromdatabase.Ucak.HavaYolu = context.HavaYollari.Where(k => k.HavaYoluID == datafromdatabase.Ucak.HavaYoluID).FirstOrDefault();


            List<SelectListItem> musaitkoltuklar = new List<SelectListItem>();
            for (var item=1;item< datafromdatabase.Ucak.Kapasite+1;item++)
            {
                if (alinmiskoltuklar.Contains(item))
                {
                    continue;
                }
                musaitkoltuklar.Add(new SelectListItem
                {
                    Text = item.ToString(), // Göstermek istediğiniz alanın adı
                    Value = item.ToString() // Seçilen değerin değeri
                });
            }



            ViewBag.musaitkoltuklar=musaitkoltuklar;
            ViewBag.KullaniciID =User.FindFirst(ClaimTypes.NameIdentifier).Value;
            ViewBag.Ucus = datafromdatabase;

            return View();
        }

        [HttpPost]
        public IActionResult SatinAlOnay(string UcusID,int koltukno)
        {
            Bilet bilet = new Bilet();
            bilet.UcusID =int.Parse( UcusID);
            bilet.KullaniciID=int.Parse( User.FindFirst(ClaimTypes.NameIdentifier).Value);
            bilet.KoltukNo = koltukno;

            context.Biletler.Add(bilet);
            context.SaveChanges();
            TempData["msj"] =bilet.BiletId +" id li biletiniz alındı ";
            return RedirectToAction("Index","Arama");
        }


        public IActionResult KullaniciBiletler()
        {
            int kullaniciid = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            var datafromdatabase=context.Biletler.Where(k=>k.KullaniciID==kullaniciid).ToList();

            foreach (var item in datafromdatabase)
            {
                item.Ucus = context.Ucuslar.Where(k => k.UcusID == item.UcusID).FirstOrDefault();
                item.Kullanici = context.Kullancilar.Where(k => k.KullaniciID == kullaniciid).FirstOrDefault();
                item.Ucus.Kalkis = context.HavaAlanlari.Where(k => k.HavaAlaniID == item.Ucus.KalkisID).FirstOrDefault();
                item.Ucus.Varis = context.HavaAlanlari.Where(k => k.HavaAlaniID == item.Ucus.VarisID).FirstOrDefault();
            }

            return View(datafromdatabase);

        }

        public IActionResult BiletDelete(int id)
        {
            int kullaniciid = id;
            if (User.IsInRole("Admin"))
            {
                kullaniciid=context.Biletler.Where(k=>k.BiletId==id).FirstOrDefault().KullaniciID;
            }

            var datafromdatabase = context.Biletler.Where(k => k.KullaniciID == kullaniciid).FirstOrDefault();


            datafromdatabase.Ucus = context.Ucuslar.Where(k => k.UcusID == datafromdatabase.UcusID).FirstOrDefault();
            datafromdatabase.Kullanici = context.Kullancilar.Where(k => k.KullaniciID == kullaniciid).FirstOrDefault();
            datafromdatabase.Ucus.Kalkis = context.HavaAlanlari.Where(k => k.HavaAlaniID == datafromdatabase.Ucus.KalkisID).FirstOrDefault();
            datafromdatabase.Ucus.Varis = context.HavaAlanlari.Where(k => k.HavaAlaniID == datafromdatabase.Ucus.VarisID).FirstOrDefault();
           

            return View(datafromdatabase);
          
        }

        [HttpPost]
        public IActionResult BiletDeletee(int id)
        {
            int kullaniciid = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            
            var datafromdatabase = context.Biletler.Where(k => k.BiletId == id).FirstOrDefault();
            if (kullaniciid != datafromdatabase.KullaniciID)
            {
                TempData["msj"] ="Bu bileti silmeye yetkin yok ";
                return RedirectToAction("KullaniciBiletler", "Bilet");
            }
            int temp = datafromdatabase.BiletId;
            TempData["msj"] = temp + " id li bilet silindi ";

            context.Biletler.Remove(datafromdatabase);
            context.SaveChanges();
            return RedirectToAction("KullaniciBiletler", "Bilet");
        }

    }
}
