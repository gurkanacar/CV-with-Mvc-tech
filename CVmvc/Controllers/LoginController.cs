using CVmvc.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CVmvc.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(TBL_ADMIN p)
        {
            DbCvEntities db = new DbCvEntities();
            var bilgi = db.TBL_ADMIN.FirstOrDefault(x => x.USERNAME == p.USERNAME && x.PASSWORD == p.PASSWORD);
            if(bilgi !=null)
            {
                FormsAuthentication.SetAuthCookie(bilgi.USERNAME, false);
                Session["USERNAME"] = bilgi.USERNAME.ToString();
                return RedirectToAction("Index", "Experiance");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
    }
}