using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CvMvc.Models.Entity;
using CvMvc.Repositories;

namespace CvMvc.Controllers
{
    public class SosyalMedyaController : Controller
    {
        // GET: SosyalMedya
        GenericRepository<TblSosyalMedya> repo = new GenericRepository<TblSosyalMedya>();

        public ActionResult Index()
        {
            var veriler = repo.List();
            return View(veriler);
        }
        [HttpGet]
        public ActionResult Ekle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Ekle(TblSosyalMedya t)
        {
            repo.TAdd(t);
            return RedirectToAction("Index");
        }

        public ActionResult Sil(int id)
        {

            TblSosyalMedya t = repo.Find(x => x.ID == id);
            repo.TDelete(t);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Getir(int id)
        {

            TblSosyalMedya t = repo.Find(x => x.ID == id);
            return View(t);
        }

        [HttpPost]
        public ActionResult Getir(TblSosyalMedya p)
        {
            TblSosyalMedya t = repo.Find(x => x.ID == p.ID);
            t.Ad = p.Ad;
            t.Link = p.Link;
            t.ikon = p.ikon;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}