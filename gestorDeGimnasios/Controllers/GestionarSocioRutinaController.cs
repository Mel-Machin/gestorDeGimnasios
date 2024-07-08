using gestorDeGimnasios.Models;
using gestorDeGimnasios.Models.DataObjets.DAO;
using Microsoft.AspNetCore.Mvc;

namespace gestorDeGimnasios.Controllers{
    public class GestionarSocioRutinaController:Controller{

        

        public ActionResult GestionandoSocioRutina(int idSocio){
            Socio socio  = new SocioRepositorio().ObtenerSocio(idSocio);
            return View(socio);
        }

        
        public ActionResult RegistrarSocioRutina(int idSocio)
        {

            List<Rutina> rutinas = new RutinaRepositorio().ObtenerRutinasResgistradas();
            ViewData["rutinas"] = rutinas;

            Socio socio = new SocioRepositorio().ObtenerSocio(idSocio);
            ViewData["socio"] = socio;

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AccionRegistrarSocioRutina(SocioRutina socioRutina )
        {
            if (ModelState.IsValid)
            {
                bool resultado = new SocioRutinaRepositorio().AgregarRutinaASocio(socioRutina, socioRutina.IdSocio, socioRutina.IdRutina);
                if (resultado)
                {
                    return RedirectToAction("GestionandoSocioRutina", new { idSocio = socioRutina.IdSocio });

                }
                else
                {
                    ModelState.AddModelError("", $"Error al agregar la rutina {socioRutina.IdRutina} al socio {socioRutina.IdSocio}.");
                }
            }
            return View(socioRutina);
        }
   

        public ActionResult EditarSocioRutina(int idSocio, int idRutina)
        {

            if (idSocio != 0 && idRutina != 0)
            {
                List<Rutina> rutinas = new RutinaRepositorio().ObtenerRutinasResgistradas();
                ViewData["rutinas"] = rutinas;

                SocioRutina sociorutina = new SocioRutinaRepositorio().ObtenerRutinaSocio(idSocio, idRutina);
                return View(sociorutina);
            }
            else
            {
                return NotFound();

            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AccionEditarSocioRutina(SocioRutina socioRutina) {
            {
                if (ModelState.IsValid)
                {
                    bool resultado = new SocioRutinaRepositorio().ModificarRutinaASocio(socioRutina);
                    if (resultado)
                    {
                        return RedirectToAction("GestionandoSocioRutina", new { idSocio = socioRutina.IdSocio });
                    }
                }
                return View(socioRutina);
            }
        }
   

        public ActionResult EliminarSocioRutina(int idRutina, int idSocio)
        {
            if (idSocio != 0)
            {
                SocioRutina socioRutina = new SocioRutinaRepositorio().ObtenerRutinaSocio(idSocio, idRutina);
                return View(socioRutina);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AccionEliminarSocioRutina(SocioRutina socioRutina)
        {
            if (ModelState.IsValid)
            {
                bool resultado = new SocioRutinaRepositorio().EliminarRutinaASocio(socioRutina);
                if (resultado)
                {
                    return RedirectToAction("GestionandoSocioRutina", new { idSocio = socioRutina.IdSocio });
                }
            }
            return View(socioRutina);
        }

    }
}
