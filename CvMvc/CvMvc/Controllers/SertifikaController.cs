using CvMvc.Models.Entity;
using CvMvc.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CvMvc.Controllers
{
    public class SertifikaController : Controller
    {
        // GET: Sertifika
        SertifikaRepository sertifikaRepository = new SertifikaRepository();
        public ActionResult Index()
        {
            var sertifikalar = sertifikaRepository.List();
            return View(sertifikalar);
        }

        [HttpGet]
        public ActionResult SertifikaEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SertifikaEkle(TblSertifikalar t)
        {
            sertifikaRepository.TAdd(t);
            return RedirectToAction("Index");
        }
        public ActionResult SertifikaSil(int id)
        {

            TblSertifikalar t = sertifikaRepository.Find(x => x.ID == id);
            sertifikaRepository.TDelete(t);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult SertifikaGetir(int id)
        {

            TblSertifikalar t = sertifikaRepository.Find(x => x.ID == id);
            return View(t);
        }

        [HttpPost]
        public ActionResult SertifikaGetir(TblSertifikalar p)
        {
            TblSertifikalar t = sertifikaRepository.Find(x => x.ID == p.ID);
            t.Aciklama = p.Aciklama;

            sertifikaRepository.TUpdate(t);
            return RedirectToAction("Index");
        }

    }
}