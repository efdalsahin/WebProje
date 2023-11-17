using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SkyPioneer.Migrations;
using SkyPioneer.Models;

namespace SkyPioneer.Controllers
{
    public class HavaYoluController : Controller
    {
        ApplicationDbContext context=new ApplicationDbContext();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult HavaYoluDetails(int id)
        {
            var dataFromDatabase = context.HavaYollari.Where(k => k.HavaYoluID == id).FirstOrDefault();


            return View(dataFromDatabase);
        }
       

        public IActionResult HavaYoluCreate()
        {
            
            return View();
        }

        [HttpPost]
        public IActionResult HavaYoluCreate(HavaYolu havaYolu)
        {

            if(ModelState.IsValid)
            {
                context.HavaYollari.Add(havaYolu);
                context.SaveChanges();
                TempData["msj"] = havaYolu.Isim + " isimli havayolu oluşturuldu ";
                return RedirectToAction("HavaYoluCreate");
            }
            TempData["msj"] = havaYolu.Isim + " isimli havayolu eklenemedi ";
            return View();
        }

        public IActionResult HavaYoluDelete(int id)
        {
            var dataFromDatabase = context.HavaYollari.Where(k => k.HavaYoluID == id).FirstOrDefault();




            return View(dataFromDatabase);

        }

        [HttpPost]
        public IActionResult HavaYoluDeletee(int id)
        {
            var dataFromDatabase = context.HavaYollari.Where(k => k.HavaYoluID == id).FirstOrDefault();
            int temp = dataFromDatabase.HavaYoluID;
            TempData["msj"] = temp + " id li havayolu silindi ";

            context.HavaYollari.Remove(dataFromDatabase);
            context.SaveChanges();
            return RedirectToAction("HavaYollariDetails", "Admin");
        }
    }
}
