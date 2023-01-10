using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CVmvc.Models.Entity;
using CVmvc.repositories;

namespace CVmvc.Controllers
{
    public class SosyalMedyaController : Controller
    {
        // GET: SosyalMedya
        GenericRepository<TblSosyalMedya> repo = new GenericRepository<TblSosyalMedya>();
        public ActionResult Index()
        {
            var veri = repo.List();
            return View(veri);
        }

        [HttpGet]
        public ActionResult Ekle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Ekle(TblSosyalMedya p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult SayfaGetir(int id)
        {
            var hesap = repo.Find(x => x.id == id);
            return View(hesap);       
        }
        [HttpPost]
        public ActionResult SayfaGetir(TblSosyalMedya p)
        {
            var hesap = repo.Find(x => x.id ==p.id);
            hesap.Ad = p.Ad;
            hesap.Durum =true;
            hesap.Link = p.Link;
            hesap.icon = p.icon;
            repo.TUpdate(hesap);
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id)
        {
            var hesap = repo.Find(x => x.id == id);
            hesap.Durum = false;
            repo.TUpdate(hesap);
            return RedirectToAction("Index");
        }
    }
}