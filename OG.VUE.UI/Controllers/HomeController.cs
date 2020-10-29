using OG.VUE.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OG.VUE.UI.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetPersonas()
        {
            List<Persona> listaPersonas = new List<Persona>();
            using (SQLDB db = new SQLDB())
            {
                listaPersonas = db.Persona.ToList();
            }
            return Json(listaPersonas, JsonRequestBehavior.AllowGet);
        }
        public JsonResult AddPersonas(Persona p)
        {
            Persona newPersona = new Persona();
            List<Persona> listaPersonas = new List<Persona>();
            using (SQLDB db = new SQLDB())
            {
                p.FechaN = DateTime.Now;
                db.Persona.Add(p);
                db.SaveChanges();
                listaPersonas = db.Persona.ToList();
            }
            return Json(listaPersonas, JsonRequestBehavior.AllowGet);
        }
        public JsonResult DeletePersonas(int id)
        {
            Persona newPersona = new Persona();
            List<Persona> listaPersonas = new List<Persona>();
            using (SQLDB db = new SQLDB())
            {
                newPersona = db.Persona.Find(id);
                db.Persona.Remove(newPersona);
                db.SaveChanges();
                listaPersonas = db.Persona.ToList();
            }
            return Json(listaPersonas, JsonRequestBehavior.AllowGet);
        }
        public JsonResult UpdatePersonas(Persona p)
        {
            Persona oldPersona = new Persona();
            List<Persona> listaPersonas = new List<Persona>();
            using (SQLDB db = new SQLDB())
            {
                db.Persona.Find(p.Id).Nombre = p.Nombre;
                db.Persona.Find(p.Id).Edad = p.Edad;
                db.Persona.Find(p.Id).FechaN = DateTime.Now;
                db.SaveChanges();
                listaPersonas = db.Persona.ToList();
            }
            return Json(listaPersonas, JsonRequestBehavior.AllowGet);
        }
    }
}