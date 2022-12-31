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
                return View("Egitim Ekle");
            }
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
    }
}