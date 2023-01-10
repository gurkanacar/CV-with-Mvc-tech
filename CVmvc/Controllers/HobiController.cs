using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CVmvc.Models.Entity;
using CVmvc.repositories;

namespace CVmvc.Controllers
{
    public class HobiController : Controller
    {
        // GET: Hobi
        GenericRepository<TBL_HOBILERIM> repo = new GenericRepository<TBL_HOBILERIM>();
        [HttpGet]
        public ActionResult Index()
        {
            var hobiler = repo.List();
            return View(hobiler);
        }
        [HttpPost]
        public ActionResult Index(TBL_HOBILERIM p)
        {
            var t = repo.Find(x => x.ID == 1);
            t.EXPLANATION1 = p.EXPLANATION1;
            t.EXPLANATION2 = p.EXPLANATION2;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }

    }
}