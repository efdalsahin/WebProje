using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SkyPioneer.Models;

namespace SkyPioneer.Controllers
{
    public class HavaAlaniController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult HavaAlaniDetails(int id)
        {
            var dataFromDatabase = context.HavaAlanlari.Where(k => k.HavaAlaniID == id).FirstOrDefault();


            return View(dataFromDatabase);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult HavaAlaniCreate()
        {

            return View();
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult HavaAlaniCreate(HavaAlani havaAlani)
        {

            if (ModelState.IsValid)
            {
                context.HavaAlanlari.Add(havaAlani);
                context.SaveChanges();
                TempData["msj"] = havaAlani.Isim + " isimli havaalani oluşturuldu ";
                return RedirectToAction("HavaAlaniCreate");
            }
            TempData["msj"] = havaAlani.Isim + " isimli havaalani eklenemedi ";
            return View();
        }
        [Authorize(Roles = "Admin")]
        public IActionResult HavaAlaniDelete(int id)
        {
            var dataFromDatabase = context.HavaAlanlari.Where(k => k.HavaAlaniID == id).FirstOrDefault();




            return View(dataFromDatabase);

        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult HavaAlaniDeletee(int id)
        {
            var dataFromDatabase = context.HavaAlanlari.Where(k => k.HavaAlaniID == id).FirstOrDefault();
            int temp = dataFromDatabase.HavaAlaniID;
            var ucuslar=context.Ucuslar.Where(k=>k.VarisID == temp || k.KalkisID==temp).FirstOrDefault();
            if (ucuslar != null)
            {
                TempData["msj"] = temp + " id li havaalani ucuslara sahip silinemez silindi ";
                return RedirectToAction("HavaAlanlariDetails", "Admin");
            }

           TempData["msj"] = temp + " id li havaalani silindi ";
           

            context.HavaAlanlari.Remove(dataFromDatabase);
            context.SaveChanges();
            return RedirectToAction("HavaAlanlariDetails", "Admin");
        }
    }
}

