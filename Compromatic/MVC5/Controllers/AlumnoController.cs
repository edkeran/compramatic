using MVC5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5.Controllers
{
    public class AlumnoController : Controller
    {
        // GET: Alumno
        public ActionResult Index()
        {
            AlumnosContext db = new AlumnosContext();
            //List<Alumno> lista= db.Alumno.Where(a=>a.Edad>18).ToList();
            return View(db.Alumno.ToList());
        }

        public ActionResult Agregar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Agregar(Alumno a)
        {
            return View();
        }
    }
}