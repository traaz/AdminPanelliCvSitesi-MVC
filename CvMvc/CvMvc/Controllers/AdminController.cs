using CvMvc.Models.Entity;
using CvMvc.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CvMvc.Controllers
{
    public class AdminController : Controller
    {
         GenericRepository<TblAdmin> repo = new GenericRepository<TblAdmin> ();
        // GET: Admin
        public ActionResult Index()
        {
            var adminler = repo.List();
            return View(adminler);
        }

        [HttpGet]
        public ActionResult Ekle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Ekle(TblAdmin t)
        {
            repo.TAdd(t);
            return RedirectToAction("Index");
        }

        public ActionResult Sil(int id)
        {

            TblAdmin t = repo.Find(x => x.ID == id);
            repo.TDelete(t);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Getir(int id)
        {

            TblAdmin t = repo.Find(x => x.ID == id);
            return View(t);
        }

        [HttpPost]
        public ActionResult Getir(TblAdmin p)
        {
            TblAdmin t = repo.Find(x => x.ID == p.ID);
            t.KullaniciAdi= p.KullaniciAdi;
            t.Sifre = p.Sifre;


            repo.TUpdate(t);
            return RedirectToAction("Index");
        }

    }
}