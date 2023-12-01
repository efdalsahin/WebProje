using Microsoft.AspNetCore.Mvc;
using SkyPioneer.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SkyPioneer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkyPioneerApiController : ControllerBase
    {
        ApplicationDbContext context=new ApplicationDbContext();
        // GET: api/<SkyPionnerApiController>
        [HttpGet]
        public IEnumerable<Ucus> GetUcusListele()
        {
            var dataFromDatabase = context.Ucuslar.ToList();


            foreach (var item in dataFromDatabase)
            {
                item.Kalkis = context.HavaAlanlari.Where(k => k.HavaAlaniID == item.KalkisID).FirstOrDefault();
                item.Varis = context.HavaAlanlari.Where(k => k.HavaAlaniID == item.VarisID).FirstOrDefault();
                item.Ucak = context.Ucaklar.Where(k => k.UcakID == item.UcakID).FirstOrDefault();


            }
            return dataFromDatabase;
        }

        // GET api/<SkyPionnerApiController>/5
        [HttpGet("hesapguncelle/{id}/{sifre}")]
        public string Get(int id,string sifre)
        {
            var datafromdatabase = context.Kullancilar.Where(k => k.KullaniciID==id).FirstOrDefault();
            datafromdatabase.Sifre= sifre;
            context.SaveChanges();
            return "Başarılı";
        }

        // POST api/<SkyPionnerApiController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<SkyPionnerApiController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SkyPionnerApiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
