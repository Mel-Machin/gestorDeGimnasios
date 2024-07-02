using gestorDeGimnasios.Models;
using gestorDeGimnasios.Models.DataObjets.DAO;
using Microsoft.AspNetCore.Mvc;

namespace gestorDeGimnasios.Controllers{
    public class GestionarSocioRutinaController:Controller{

        

        public ActionResult GestionandoSocioRutina(int idSocio){
            Socio socio  = new SocioRepositorio().ObtenerSocio(idSocio);
            return View(socio);
        }


        public ActionResult RegistrarSocioRutina()
        {
            List<Rutina> rutinas = new RutinaRepositorio().ObtenerRutinasResgistradas();
            ViewData["rutinas"] = rutinas;

            List<Socio> socios = new SocioRepositorio().ObtenerSociosRegistrados();
            ViewData["socios"] = socios;

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
                    return RedirectToAction("GestionandoSocioRutina");
                }
                else
                {
                    ModelState.AddModelError("", $"Error al agregar la rutina {socioRutina.IdRutina} al socio {socioRutina.IdSocio}.");
                }
            }
            return View(socioRutina);
        }
    }
}
