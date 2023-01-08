using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CVmvc.Models.Entity;
using CVmvc.repositories;

namespace CVmvc.Controllers
{
    public class EgitimController : Controller
    {
        // GET: Egitim
        GenericRepository<TBL_EDUCATION> repo = new GenericRepository<TBL_EDUCATION>();
        public ActionResult Index()
        {
            var egitim = repo.List();
            return View(egitim);
        }
        [HttpGet]
        public ActionResult EgitimEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult EgitimEkle(TBL_EDUCATION p)
        {
            if (!ModelState.IsValid) 
            {
                return View("EgitimEkle");
            }
            else
            {

                repo.TAdd(p);
                return RedirectToAction("Index");
            }
        }

        public ActionResult EgitimSil(int id)
        {
            var egitim = repo.Find(x => x.ID == id);
            repo.TDelete(egitim);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EgitimDuzenle(int id)
        {
            var egitim = repo.Find(x => x.ID == id);
            repo.TUpdate(egitim);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult EgitimDuzenle(TBL_EDUCATION t)
        {
            if (!ModelState.IsValid)
            {
                return View("EgitimDuzenle");
            }
            var egitim = repo.Find(x => x.ID == t.ID);
            egitim.HEADING = t.HEADING;
            egitim.HEADINGBELOW = t.HEADINGBELOW;
            egitim.HEADINGBELOW2 = t.HEADINGBELOW2;
            egitim.DATE = t.DATE;
            egitim.GNO = t.GNO;
            repo.TUpdate(egitim);
            return RedirectToAction("Index");
        }

    }
}