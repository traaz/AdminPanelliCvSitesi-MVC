using CvMvc.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CvMvc.Controllers
{
    public class IletisimController : Controller
    {
        // GET: Iletisim
        IletisimRepository iletisimRepo=new IletisimRepository();
        public ActionResult Index()
        {
            var mesajlar = iletisimRepo.List();
            return View(mesajlar);
        }
    }
}