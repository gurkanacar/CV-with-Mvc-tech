using CVmvc.Models.Entity;
using CVmvc.repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CVmvc.Controllers
{
    public class ExperianceController : Controller
    {
        // GET: Experiance
        DeneyimRepository repo = new DeneyimRepository();
        public ActionResult Index()
        {
            var degerler = repo.List();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult DeneyimEkle() 
        {
            return View();
        }
        [HttpPost]
        public ActionResult DeneyimEkle(TBL_EXPERIANCE p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult DeneyimSil(int id)
        {
            TBL_EXPERIANCE t = repo.Find(x => x.ID == id);
            repo.TDelete(t);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult DeneyimGetir(int id)
        {
            TBL_EXPERIANCE t = repo.Find(x => x.ID == id);
            return View(t);
        }
        [HttpPost]
        public ActionResult DeneyimGetir(TBL_EXPERIANCE p)
        {
            TBL_EXPERIANCE t = repo.Find(x => x.ID == p.ID);
            t.HEAD = p.HEAD;
            t.HEADBELOW = p.HEADBELOW;
            t.DATE = p.DATE;
            t.EXPLANATION = p.EXPLANATION;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}