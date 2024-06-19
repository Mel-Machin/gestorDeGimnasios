using gestorDeGimnasios.Models;
using gestorDeGimnasios.Models.DataObjets.DAO;
using Microsoft.AspNetCore.Mvc;

namespace gestorDeGimnasios.Controllers
{
    public class GestionarSocioController : Controller
    {   /*
        public List<Socio> obtenerSociosSegunTipo(string tipoSocio)
        {
            return new SocioRepositorio().ObtenerSociosSegunTipo(tipoSocio);
        }*/
        //Vista principal de gestion de socio
        public ActionResult GestionandoSocio() { 
            List<Socio> socios = new SocioRepositorio().ObtenerSociosRegistrados(); 
            return View(socios);
        }

        //Vista de editar socio
        public ActionResult EditarSocio(int idSocio)
        {
            if (idSocio != 0)
            {
                Socio socio = new SocioRepositorio().ObtenerSocio(idSocio);
                return View(socio);
            }
            else
            {
                return NotFound();

            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AccionEditarSocio(Socio socio)
        {
            if (ModelState.IsValid)
            {
                bool resultado = new SocioRepositorio().ModificarSocio(socio, socio.IdSocio);
                if (resultado)
                {
                    return RedirectToAction("GestionandoSocio");
                }
            }
            return View(socio);
        }

        //Vista de eliminar socio
        public ActionResult EliminarSocio(int idSocio)
        {
            if (idSocio != 0)
            {
                Socio socio = new SocioRepositorio().ObtenerSocio(idSocio);
                return View(socio);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AccionEliminarSocio(Socio socio)
        {
            if (ModelState.IsValid)
            {
                bool resultado = new SocioRepositorio().EliminarSocio(socio.IdSocio);
                if (resultado)
                {
                    return RedirectToAction("GestionandoSocio");
                }
            }
            return View(socio);
        }

        //Vista registrar socio
        public ActionResult RegistrarSocio()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AccionRegistrarSocio(Socio socio)
        {
            if (ModelState.IsValid)
            {
                bool resultado = new SocioRepositorio().RegistrarSocio(socio);
                if (resultado)
                {
                    return RedirectToAction("GestionandoSocio");
                }
                else
                {
                    ModelState.AddModelError("", "Error al registrar el socio.");
                }
            }
            return View(socio);
        }

    }
}
