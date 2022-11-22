using CvMvc.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CvMvc.Controllers
{
    
    [AllowAnonymous]
    
    public class LogInController : Controller
    {
        // GET: LogIn
        [HttpGet]
      
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(TblAdmin a)
        {
            DbCvEntities db=new DbCvEntities();
            var bilgi = db.TblAdmin.FirstOrDefault(x => x.KullaniciAdi == a.KullaniciAdi && x.Sifre == a.Sifre);
            if(bilgi != null)
            {
                FormsAuthentication.SetAuthCookie(bilgi.KullaniciAdi,false);
                Session["KullaniciAdi"] = bilgi.KullaniciAdi.ToString();
                return RedirectToAction("Index", "Hakkimda");
            }
            else
            {
                return RedirectToAction("Index", "logIn");
            }
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "LogIn");
        }
    }
}