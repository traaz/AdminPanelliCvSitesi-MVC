using CvMvc.Models.Entity;
using CvMvc.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CvMvc.Controllers
{
   

    public class HobiController : Controller
    {
        // GET: Hobi
        HobiRepository hobiRepository=new HobiRepository();
        public ActionResult Index()
        {
            var hobiler = hobiRepository.List();
            return View(hobiler);
        }


        [HttpGet]
        public ActionResult HobiEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult HobiEkle(TblHobiler t)
        {
            hobiRepository.TAdd(t);
            return RedirectToAction("Index");
        }
        public ActionResult HobiSil(int id)
        {

            TblHobiler t = hobiRepository.Find(x => x.ID == id);
            hobiRepository.TDelete(t);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult HobiGetir(int id)
        {

            TblHobiler t = hobiRepository.Find(x => x.ID == id);
            return View(t);
        }

        [HttpPost]
        public ActionResult HobiGetir(TblHobiler p)
        {
            TblHobiler t = hobiRepository.Find(x => x.ID == p.ID);
            t.Aciklama1 = p.Aciklama1;

            hobiRepository.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}