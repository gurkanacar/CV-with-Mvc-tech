using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CVmvc.Models.Entity;
using CVmvc.repositories;

namespace CVmvc.Controllers
{
    public class iletisimController : Controller
    {
        // GET: iletisim
        GenericRepository<TBL_CONNECT> repo = new GenericRepository<TBL_CONNECT>();

        public ActionResult Index()
        {
            var mesajlar = repo.List();
            return View(mesajlar);
        }
    }
}