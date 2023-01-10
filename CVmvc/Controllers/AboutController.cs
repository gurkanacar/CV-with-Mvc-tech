using CVmvc.Models.Entity;
using CVmvc.repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CVmvc.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        GenericRepository<TBL_ABOUT> repo = new GenericRepository<TBL_ABOUT>();
        [HttpGet]
        public ActionResult Index()
        {
            var hakkimda = repo.List();
            return View(hakkimda);
        }
        [HttpPost]
        public ActionResult Index(TBL_ABOUT p)
        {
            var t = repo.Find(x => x.ID == 1);
            t.NAME = p.NAME;
            t.SURNAME = p.SURNAME;
            t.ADDRESS = p.ADDRESS;
            t.MAIL = p.MAIL;
            t.PHONE = p.PHONE;
            t.EXPLANATION = p.EXPLANATION;
            t.PHOTO = p.PHOTO;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}