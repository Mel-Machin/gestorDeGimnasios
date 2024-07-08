using gestorDeGimnasios.Models.DataObjets.DAO;
using gestorDeGimnasios.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using gestorDeGimnasios.Data;

namespace gestorDeGimnasios.Controllers
{
    public class GestionarRutinaEjercicioController:Controller
    {
        public ActionResult EliminarRutinaEjercicio(int idEjercicio, int idRutina)
        {

            if (idEjercicio != 0 && idRutina != 0)
            {

                ViewData["idEjercicio"] = idEjercicio;
                ViewData["idRutina"] = idRutina;


                return View();
            }
            else
            {
                return NotFound();

            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AccionEliminarEjercicioRutina(int idEjercicio, int idRutina)
        {
           
            {
                if (idEjercicio != 0 && idRutina != 0)
                {
                    Rutina rutina = new RutinaRepositorio().ObtenerRutina(idRutina);
                    bool resultado = new RutinaEjercicioRepositorio().EliminarEjercicioDeRutina(idRutina, idEjercicio);
                    if (resultado)
                    {
                        return RedirectToAction("EjerciciosRutina","GestionarEjercicio",rutina);
                    }
                }
                return  NotFound();
            }
        }

        public ActionResult RegistrarRutinaEjercicio(int idRutina)
        {

            if (idRutina != 0)
            {

                ViewData["ejercicios"] = new EjercicioRepositorio().ObtenerEjerciciosRegistrados();
                ViewData["rutina"] = new RutinaRepositorio().ObtenerRutina(idRutina);


                return View();
            }
            else
            {
                return NotFound();

            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AccionRegistrarRutinaEjercicio(int idEjercicio, int idRutina)
        {

            {
                if (idEjercicio != 0 && idRutina != 0)
                {
                    if(!(new RutinaEjercicioRepositorio().ExisteEjercicioRutina(idRutina, idEjercicio)))
                    {
                        Rutina rutina = new RutinaRepositorio().ObtenerRutina(idRutina);
                        bool resultado = new RutinaEjercicioRepositorio().AgregarEjercicioARutina(idRutina, idEjercicio);
                        if (resultado)
                        {
                            return RedirectToAction("EjerciciosRutina", "GestionarEjercicio", rutina);
                        }
                    }else
                    {
                        ViewData["ejercicios"] = new EjercicioRepositorio().ObtenerEjerciciosRegistrados();
                        ViewData["rutina"] = new RutinaRepositorio().ObtenerRutina(idRutina);
                        ModelState.AddModelError("", "La rutina ya contiene ese ejercicio");
                        return View("RegistrarRutinaEjercicio",new {idRutina=idRutina});
                      
                    }
            
                }
                return NotFound();
            }
        }
    }
}
