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
            using (var db = new AlumnosContext())
            {
                //List<Alumno> lista= db.Alumno.Where(a=>a.Edad>18).ToList();
                return View(db.Alumno.ToList());
            }
        }

        public ActionResult Agregar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Agregar(Alumno a)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                using (var db = new AlumnosContext())
                {
                    a.FechaRegistro = DateTime.Now;
                    db.Alumno.Add(a);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "ERROR AL CREAR ALUMNO " + ex.Message);
                return View();
            }
        }

        public ActionResult Editar(int id)
        {
            try
            {
                using (var db = new AlumnosContext())
                {
                    return View(db.Alumno.Find(id));
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Alumno a)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View();

                using (var db= new AlumnosContext())
                {
                    Alumno al = db.Alumno.Find(a.id);
                    al.Nombres = a.Nombres;
                    al.Sexo = a.Sexo;
                    al.Apellidos = a.Apellidos;
                    al.Edad = a.Edad;
                    al.codCurso = a.codCurso;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                } 
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }

        public ActionResult Detalles(int id)
        {
            using (var db= new AlumnosContext())
            {
                Alumno alu = db.Alumno.Find(id);
                return View(alu);
            }
        }

        public ActionResult EliminarAlumno(int id)
        {
            using (var db = new AlumnosContext())
            {
                Alumno al=db.Alumno.Find(id);
                db.Alumno.Remove(al);
                db.SaveChanges();
                return RedirectToAction("Index");
            } 
        }

        public ActionResult Agregar2()
        {
            return View();
        }

        public ActionResult ListaCiudades()
        {
            using (var db = new AlumnosContext())
            {
                return PartialView(db.curso2.ToList());
            }
        }

        public static string Nombre_Grado(int? codCurso)
        {
            using (var db=new AlumnosContext())
            {
                var data = db.curso2.Find(codCurso);
                return data.nom_curso;
            }
        }
    }
}