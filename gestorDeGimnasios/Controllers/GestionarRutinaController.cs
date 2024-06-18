using gestorDeGimnasios.Models;
using gestorDeGimnasios.Models.DataObjets.DAO;
using Microsoft.AspNetCore.Mvc;

namespace gestorDeGimnasios.Controllers
{
    public class GestionarRutinaController : Controller
    {
        //Vista principal Gestion de rutinas 
        public ActionResult GestionandoRutina()
        {
            List<Rutina> rutinas = new RutinaRepositorio().ObtenerRutinasResgistradas();
            return View(rutinas);
        }

        //Vista de editar rutina
        public ActionResult EditarRutina(int idRutina)
        {
            if (idRutina != 0)
            {
                Rutina rutina = new RutinaRepositorio().ObtenerRutina(idRutina);
                return View(rutina);
            }
            else
            {
                return NotFound();

            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AccionEditarRutina(Rutina rutina)
        {
            if (ModelState.IsValid)
            {
                bool resultado = new RutinaRepositorio().ModificarRutina(rutina, rutina.IdRutina);
                if (resultado)
                {
                    return RedirectToAction("GestionandoRutina");
                }
            }
            return View(rutina);
        }


        //Vista de eliminar rutina
        public ActionResult EliminarRutina(int idRutina)
        {
            if (idRutina != 0)
            {
                Rutina rutina = new RutinaRepositorio().ObtenerRutina(idRutina);
                return View(rutina);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AccionEliminarRutina(Rutina rutina)
        {
            if (ModelState.IsValid)
            {
                bool resultado = new RutinaRepositorio().EliminarRutina(rutina.IdRutina);
                if (resultado)
                {
                    return RedirectToAction("GestionandoRutina");
                }
            }
            return View(rutina);
        }


        //Vista de registrar rutina
        public ActionResult RegistrarRutina()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AccionRegistrarRutina(Rutina rutina)
        {
            if (ModelState.IsValid)
            {
                bool resultado = new RutinaRepositorio().RegistrarRutina(rutina);
                if (resultado)
                {
                    return RedirectToAction("GestionandoRutina");
                }
                else
                {
                    ModelState.AddModelError("", "Error al registrar la rutina.");
                }
            }
            return View(rutina);
        }
    }
}
