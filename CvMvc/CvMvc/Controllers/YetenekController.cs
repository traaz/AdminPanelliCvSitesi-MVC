using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CvMvc.Models.Entity;
using CvMvc.Repositories;
namespace CvMvc.Controllers
{
    public class YetenekController : Controller
    {
        // GET: Yetenek
        YetenekRepository yetenekRepo=new YetenekRepository();
        public ActionResult Index()
        {
            var yetenekler = yetenekRepo.List();
            return View(yetenekler);
        }

        [HttpGet]
        public ActionResult YetenekEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YetenekEkle(TblYetenekler t)
        {
            yetenekRepo.TAdd(t);
            return RedirectToAction("Index");
        }

        public ActionResult YetenekSil(int id)
        {

            TblYetenekler t = yetenekRepo.Find(x => x.ID == id);
            yetenekRepo.TDelete(t);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult YetenekGetir(int id)
        {

            TblYetenekler t = yetenekRepo.Find(x => x.ID == id);
            return View(t);
        }

        [HttpPost]
        public ActionResult YetenekGetir(TblYetenekler p)
        {
            TblYetenekler t = yetenekRepo.Find(x => x.ID == p.ID);
            t.Yetenek = p.Yetenek;
  
            yetenekRepo.TUpdate(t);
            return RedirectToAction("Index");
        }

    }
}