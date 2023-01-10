using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CVmvc.repositories;
using CVmvc.Models.Entity;


namespace CVmvc.Controllers
{
    public class SertifikaController : Controller
    {
        GenericRepository<TBL_SERTIFIKA> repo = new GenericRepository<TBL_SERTIFIKA>();

        public ActionResult Index()
        {
            var sertifika = repo.List();
            return View(sertifika);
        }
        [HttpGet]
        public ActionResult SertifikaGetir(int id)
        {
            var sertifika = repo.Find(x => x.ID ==id);
            ViewBag.d = id;
            return View(sertifika);
        }
        [HttpPost]
        public ActionResult SertifikaGetir(TBL_SERTIFIKA t)
        {
            var sertifika = repo.Find(x => x.ID == t.ID);
            sertifika.EXPLANATION = t.EXPLANATION;
            sertifika.Tarih = t.Tarih;
            repo.TUpdate(sertifika);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult YeniSertifika()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniSertifika(TBL_SERTIFIKA p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult SertifikaSil(int id)
        {
            var sertifika = repo.Find(x=>x.ID==id);
            repo.TDelete(sertifika);
            return RedirectToAction("Index");
        }

    }
}