using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SkyPioneer.Migrations;
using SkyPioneer.Models;

namespace SkyPioneer.Controllers
{
    public class UcakController : Controller
    {
        ApplicationDbContext context=new ApplicationDbContext();
        public IActionResult Index()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        public IActionResult UcakCreate()
        {

            var datafromDatabase = context.HavaYollari.ToList();

            List<SelectListItem> selectListItems = new List<SelectListItem>();
            foreach (var item in datafromDatabase)
            {
                selectListItems.Add(new SelectListItem
                {
                    Text = item.Isim, // Göstermek istediğiniz alanın adı
                    Value = item.HavaYoluID.ToString() // Seçilen değerin değeri
                });
            }
            ViewBag.liste = selectListItems;
            return View();
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult UcakCreate(Ucak ucak)
        {
            ModelState.Remove("HavaYolu");
            ucak.HavaYolu=context.HavaYollari.Where(k=>k.HavaYoluID==ucak.HavaYoluID).FirstOrDefault();
            if (ModelState.IsValid){ 
                
                context.Ucaklar.Add(ucak);
                context.SaveChanges();
                TempData["msj"] = ucak.UcakID+ " id li ucak oluşturuldu ";
                return RedirectToAction("UcakCreate");

            }
            TempData["msj"] = ucak.UcakID + " id li ucak oluşturulamadı ";
            return View();

        }
        [Authorize(Roles = "Admin")]
        public IActionResult UcakDelete(int id)
        {
            var dataFromDatabase = context.Ucaklar.Where(k => k.UcakID == id).FirstOrDefault();

            dataFromDatabase.HavaYolu = context.HavaYollari.Where(k => k.HavaYoluID == dataFromDatabase.HavaYoluID).FirstOrDefault();
           



            return View(dataFromDatabase);

        }
        [Authorize(Roles = "Admin")]
        public IActionResult UcakDeletee(int id)
        {
            var dataFromDatabase = context.Ucaklar.Where(k => k.UcakID == id).FirstOrDefault();
            int temp = dataFromDatabase.UcakID;
            TempData["msj"] = temp + " id li uçak silindi ";

            context.Ucaklar.Remove(dataFromDatabase);
            context.SaveChanges();
            return RedirectToAction("UcaklarDetails", "Admin");
        }

        public IActionResult UcakDetails(int id)
        {
            var dataFromDatabase = context.Ucaklar.Where(k => k.UcakID == id).FirstOrDefault();

            dataFromDatabase.HavaYolu = context.HavaYollari.Where(k => k.HavaYoluID == dataFromDatabase.HavaYoluID).FirstOrDefault();

            return View(dataFromDatabase);

        }
    }
}
