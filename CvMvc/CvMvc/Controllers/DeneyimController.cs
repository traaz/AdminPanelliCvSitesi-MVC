﻿using CvMvc.Models.Entity;
using CvMvc.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CvMvc.Controllers
{
    public class DeneyimController : Controller
    {
        // GET: Deneyim
        DeneyimRepository deneyimRepository=new DeneyimRepository();
        public ActionResult Index()
        {
            var deneyimler = deneyimRepository.List();

            return View(deneyimler);
        }
        [HttpGet]
        public ActionResult DeneyimEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DeneyimEkle(TblDeneyimler t)
        {
            deneyimRepository.TAdd(t);
            return RedirectToAction("Index");
        }
        
        public ActionResult DeneyimSil(int id)
        {
         
            TblDeneyimler t = deneyimRepository.Find(x => x.ID == id);
            deneyimRepository.TDelete(t);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult DeneyimGetir(int id)
        {

            TblDeneyimler t = deneyimRepository.Find(x => x.ID == id);
            return View(t);
        }

        [HttpPost]
        public ActionResult DeneyimGetir(TblDeneyimler p)
        {
            TblDeneyimler t=deneyimRepository.Find(x=>x.ID == p.ID);
            t.Baslik = p.Baslik;
            t.AltBaslik = p.AltBaslik;
            t.Tarih = p.Tarih;
            t.Aciklama = p.Aciklama;

            deneyimRepository.TUpdate(t);
            return RedirectToAction("Index");
        }

    }
}