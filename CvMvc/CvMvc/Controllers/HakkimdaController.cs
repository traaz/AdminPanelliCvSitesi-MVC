using CvMvc.Models.Entity;
using CvMvc.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CvMvc.Controllers
{


    public class HakkimdaController : Controller
    {
        // GET: Hakkimda
        HakkindaRepository hakkindaRepository=new HakkindaRepository();
        [HttpGet]
        public ActionResult Index()
        {
            var hakkinda = hakkindaRepository.List();
            return View(hakkinda);
        }
        [HttpPost]
        public ActionResult Index(TblHakkimda p)
        {
            var t = hakkindaRepository.Find(x => x.ID == 1);
            t.Ad = p.Ad;
            t.Soyad = p.Soyad;
            t.Adres = p.Adres;
            t.Mail = p.Mail;
            t.Telefon = p.Telefon;
            t.Aciklama = p.Aciklama;
            t.Resim = p.Resim;
            hakkindaRepository.TUpdate(p);
            return RedirectToAction("Index");

        }
    }
}