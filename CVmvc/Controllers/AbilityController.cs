using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CVmvc.Models.Entity;
using CVmvc.repositories;

namespace CVmvc.Controllers
{
    public class AbilityController : Controller
    {
        // GET: Ability
        GenericRepository<TBL_ABILITY> repo = new GenericRepository<TBL_ABILITY>();

        public ActionResult Index()
        {
            var yetenekler = repo.List();
            return View(yetenekler);
        }
        [HttpGet]
        public ActionResult NewAbility()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewAbility(TBL_ABILITY t)
        {
            repo.TAdd(t);
            return RedirectToAction("Index");
        }

        public ActionResult AbilityDelete(int id)
        {
            var yetenek = repo.Find(x => x.ID == id);
            repo.TDelete(yetenek);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult YetenekDuzenle(int id)
        {
            var yetenek = repo.Find(x => x.ID == id);
            return View(yetenek);
        }
        [HttpPost]
        public ActionResult YetenekDuzenle(TBL_ABILITY t)
        {
            var y = repo.Find(x => x.ID == t.ID);
            y.ABILITY = t.ABILITY;
            y.ORAN = t.ORAN;
            repo.TUpdate(y);
            return RedirectToAction("Index");
        }
    }
}