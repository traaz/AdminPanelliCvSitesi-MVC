using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Xml.Linq;
using CvMvc.Models.Entity;

namespace CvMvc.Controllers
{
    public class DefaultController : Controller
    {

        // GET: Default
        DbCvEntities db=new DbCvEntities();

        public ActionResult Index()
        {
            var degerler = db.TblHakkimda.ToList();
            return View(degerler);
        }
        public PartialViewResult SosyalMedya()
        {
            var sosyalmedya = db.TblSosyalMedya.ToList();
            return PartialView(sosyalmedya);
        }
        public PartialViewResult Deneyim()
        {
            var deneyimler=db.TblDeneyimler.ToList();
            return PartialView(deneyimler);
        }

        public PartialViewResult Egitim()
        {
            var egitimler = db.TblEgitimler.ToList();
            return PartialView(egitimler);
        }

        public PartialViewResult Yetenek()
        {
            var yetenekler = db.TblYetenekler.ToList();
            return PartialView(yetenekler);
        }
        public PartialViewResult Hobi()
        {
            var hobiler = db.TblHobiler.ToList();
            return PartialView(hobiler);
        }
        public PartialViewResult Sertifika()
        {
            var sertifikalar = db.TblSertifikalar.ToList();
            return PartialView(sertifikalar);
        }
        [HttpGet]
        public PartialViewResult Iletisim()
        {
            
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult Iletisim(Tbliletisim t)
        {
            
            t.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.Tbliletisim.Add(t);
            db.SaveChanges();
            return PartialView();
        }
    }
}