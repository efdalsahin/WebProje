using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SkyPioneer.Migrations;
using SkyPioneer.Models;

namespace SkyPioneer.Controllers
{
    public class UcusController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();

        // GET: UcusController
        public ActionResult Index()
        {
            return View();
        }

        // GET: UcusController/Details/5
        public ActionResult UcusDetails(int id)
        {

            var dataFromDatabase = context.Ucuslar.Where(k=> k.UcusID==id).FirstOrDefault();

            dataFromDatabase.Kalkis=context.HavaAlanlari.Where(k => k.HavaAlaniID == dataFromDatabase.KalkisID).FirstOrDefault();
            dataFromDatabase.Varis = context.HavaAlanlari.Where(k => k.HavaAlaniID == dataFromDatabase.VarisID).FirstOrDefault();
            dataFromDatabase.Ucak = context.Ucaklar.Where(k => k.UcakID == dataFromDatabase.UcakID).FirstOrDefault();

            

            return View(dataFromDatabase);
     
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

        // GET: UcusController/Create
        public ActionResult UcusCreate()
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

            var datafromDatabase2 = context.Ucaklar.ToList();

            List<SelectListItem> selectListItems2 = new List<SelectListItem>();
            foreach (var item in datafromDatabase2)
            {
                selectListItems2.Add(new SelectListItem
                {
                    Text = item.Modell, // Göstermek istediğiniz alanın adı
                    Value = item.UcakID.ToString() // Seçilen değerin değeri
                });
            }




            ViewBag.From = selectListItems;
            ViewBag.Ucak = selectListItems2;
            return View();
           
        }

        // POST: UcusController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UcusCreate(Ucus ucus)
        {
            ModelState.Remove("Kalkis");
            ModelState.Remove("Ucak");
            ModelState.Remove("Varis");

            if (ModelState.IsValid)
            {
                context.Ucuslar.Add(ucus);
                context.SaveChanges();
                TempData["msj"] = ucus.KalkisSaati + " saatli uçuş oluşturuldu ";
                return RedirectToAction("UcusCreate");
            }
            TempData["msj"] = ucus.KalkisSaati + " saatli uçuş eklenemedi ";
            return View();
         
        }


        // GET: UcusController/Delete/5
        public ActionResult UcusDelete(int id)
        {
            var dataFromDatabase = context.Ucuslar.Where(k => k.UcusID == id).FirstOrDefault();

            dataFromDatabase.Kalkis = context.HavaAlanlari.Where(k => k.HavaAlaniID == dataFromDatabase.KalkisID).FirstOrDefault();
            dataFromDatabase.Varis = context.HavaAlanlari.Where(k => k.HavaAlaniID == dataFromDatabase.VarisID).FirstOrDefault();
            dataFromDatabase.Ucak = context.Ucaklar.Where(k => k.UcakID == dataFromDatabase.UcakID).FirstOrDefault();



            return View(dataFromDatabase);
            
        }

        // POST: UcusController/Delete/5
        
       
        public ActionResult UcusDeletee(int id)
        {
            var dataFromDatabase = context.Ucuslar.Where(k => k.UcusID == id).FirstOrDefault();
            int temp = dataFromDatabase.UcusID;
            TempData["msj"] =temp+ " id li uçuş silindi ";

            context.Ucuslar.Remove(dataFromDatabase);
            context.SaveChanges();
            return RedirectToAction("UcuslarDetails","Admin");
        }
    }
}
