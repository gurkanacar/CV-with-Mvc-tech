using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CVmvc.Models.Entity;

namespace CVmvc.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        DbCvEntities db = new DbCvEntities();
        public ActionResult Index()
        {
            var degerler = db.TBL_ABOUT.ToList();
            return View(degerler);
        }

        public PartialViewResult SosyalMedya()
        {
            var sosyalmedya = db.TblSosyalMedyas.ToList();

            return PartialView(sosyalmedya);
        }

        public PartialViewResult Deneyim()
        {
            var deneyim1 = db.TBL_EXPERIANCE.ToList();

            return PartialView(deneyim1);
        }
        public PartialViewResult MYEDUCATION()
        {
            var myeducation = db.TBL_EDUCATION.ToList();

            return PartialView(myeducation);
        }
        public PartialViewResult ABILITY()
        {
            var yetenekler = db.TBL_ABILITY.ToList();

            return PartialView(yetenekler);
        }
        public PartialViewResult HOBILERIM()
        {
            var hobi = db.TBL_HOBILERIM.ToList();

            return PartialView(hobi);
        }
        public PartialViewResult SERTIFIKALAR()
        {
            var sertifi = db.TBL_SERTIFIKA.ToList();

            return PartialView(sertifi);
        }
        [HttpGet]
        public PartialViewResult CONNECTION()
        { 
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult CONNECTION(TBL_CONNECT t)
        {
            db.TBL_CONNECT.Add(t);
            t.DATE =DateTime.Parse( DateTime.Now.ToShortDateString());
            db.SaveChanges();
            return PartialView();
        }


    }
}