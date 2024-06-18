using gestorDeGimnasios.Models.DataObjets.DAO;
using gestorDeGimnasios.Models;
using gestorDeGimnasios.Data;
using Microsoft.AspNetCore.Mvc;

namespace gestorDeGimnasios.Controllers{
    public class GestionarEjercicioController : Controller{
        
        //Vista principal de gestion ejercicio 
        public ActionResult GestionandoEjercicio()
        { 
            List<Ejercicio> ejercicios = new EjercicioRepositorio().ObtenerEjerciciosRegistrados();
            return View(ejercicios);
        }

        //Vista editar ejercicio 
        public ActionResult EditarEjercicio(int idEjercicio)
        {
            if (idEjercicio != 0)
            {
                Ejercicio ejercicio = new EjercicioRepositorio().ObtenerEjercicio(idEjercicio);
                return View(ejercicio);
            }
            else { 
                return NotFound();
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AccionEditarEjercicio(Ejercicio ejercicio) {
            if (ModelState.IsValid)
            {
                bool resultado = new EjercicioRepositorio().ModificarEjercicio(ejercicio, ejercicio.IdEjercicio);
                if (resultado) {
                    return RedirectToAction("GestionandoEjercicio");
                }
            }
            return View(ejercicio);
        }

        //Vista eliminar ejercicio
        public ActionResult EliminarEjercicio(int idEjercicio) {

            if (idEjercicio != 0)
            {
                Ejercicio ejercicio = new EjercicioRepositorio().ObtenerEjercicio(idEjercicio);
                return View(ejercicio);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AccionEliminarEjercicio(Ejercicio ejercicio) {
            if (ModelState.IsValid)
            {
                bool resultado = new EjercicioRepositorio().EliminarEjercicio(ejercicio.IdEjercicio);
                if (resultado)
                {
                    return RedirectToAction("GestionandoEjercicio");
                }
            }
            return View(ejercicio);
        }

        //Vista de registrar 
        public ActionResult RegistrarEjercicio() { 
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AccionRegistrarEjercicio(Ejercicio ejercicio) {
            if (ModelState.IsValid)
            {
                bool resultado = new EjercicioRepositorio().RegistrarEjercicio(ejercicio);
                if (resultado)
                {
                    return RedirectToAction("GestionandoEjercicio");
                }
                else
                {
                    ModelState.AddModelError("", "Error al registrar el ejercicio.");
                }
            }
            return View(ejercicio);
        }
    }
}
