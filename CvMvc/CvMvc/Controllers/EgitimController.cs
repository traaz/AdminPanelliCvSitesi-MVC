using CvMvc.Models.Entity;
using CvMvc.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CvMvc.Controllers
{
  
    public class EgitimController : Controller
    {
        // GET: Egitim
        EgitimRepositiory egitimRepo=new EgitimRepositiory();
        
        public ActionResult Index()
        {
            var egitimler=egitimRepo.List();
            return View(egitimler);
        }
        [HttpGet]
        public ActionResult EgitimEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult EgitimEkle(TblEgitimler t)
        {
            egitimRepo.TAdd(t);
            return RedirectToAction("Index");
        }

        public ActionResult EgitimSil(int id)
        {

            TblEgitimler t = egitimRepo.Find(x => x.ID == id);
            egitimRepo.TDelete(t);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EgitimGetir(int id)
        {

            TblEgitimler t = egitimRepo.Find(x => x.ID == id);
            return View(t);
        }

        [HttpPost]
        public ActionResult EgitimGetir(TblEgitimler p)
        {
            TblEgitimler t = egitimRepo.Find(x => x.ID == p.ID);
            t.Baslik = p.Baslik;
            t.AltBaslik = p.AltBaslik;
            t.AltBaslik2 = p.AltBaslik2;
            t.GNO = p.GNO;
            t.Tarih = p.Tarih;
            

            egitimRepo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}