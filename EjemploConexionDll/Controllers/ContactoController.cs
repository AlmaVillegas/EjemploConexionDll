using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EjemploConexionDll.Models.Dao;
using EjemploConexionDll.Models.Dto;

namespace EjemploConexionDll.Controllers
{
    public class ContactoController : Controller
    {
        ContactosDao ObjetoContacto = new ContactosDao();

        public ActionResult Index()
        {
            List<ContactosDto> lstContacto = new List<ContactosDto>();
            lstContacto = ObjetoContacto.GetAllContactos().ToList();
            return View(lstContacto);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind] ContactosDto contacto)
        {
            if (ModelState.IsValid)
            {
                ObjetoContacto.AddContactos(contacto);
                return RedirectToAction("Index");
            }
            return View(contacto);
        }
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return View("Index");
            }
            ContactosDto contacto = ObjetoContacto.GetContactoData(id);
            if(contacto== null)
            {
                return View("Index");
            }
            return View(contacto);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind]ContactosDto contacto)
        {
            if(id!=contacto.Id)
            {
                return View("Index");
            }
            if (ModelState.IsValid)
            {
                ObjetoContacto.UpdateContactos(contacto);
                return RedirectToAction("Index");
            }
            return View("Index");

        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return View("Index");
            }
            ContactosDto contacto = ObjetoContacto.GetContactoData(id);
            if (contacto == null)
            {
                return View("Index");
            }
            return View(contacto); }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            ObjetoContacto.DeleteContactos(id);
            return RedirectToAction("Index");
        }


    }
}