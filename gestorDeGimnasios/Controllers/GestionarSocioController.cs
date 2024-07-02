using gestorDeGimnasios.Models;
using gestorDeGimnasios.Models.DataObjets.DAO;
using Microsoft.AspNetCore.Mvc;

namespace gestorDeGimnasios.Controllers
{
    public class GestionarSocioController : Controller
    {

        //Vista principal de gestion de socio
        public ActionResult GestionandoSocio()
        {
            List<Local> locales = new LocalRepositorio().ObtenerLocalesRegistrados();
            ViewData["locales"] = locales;
            List<Socio> socios = new SocioRepositorio().ObtenerSociosRegistrados();
            return View(socios);
        }

        //Vista de editar socio
        public ActionResult EditarSocio(int idSocio)
        {
            if (idSocio != 0)
            {
                List<Local> locales = new LocalRepositorio().ObtenerLocalesRegistrados();
                ViewData["locales"] = locales;
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

        // Vista para confirmar eliminación de socio
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

        // Acción para eliminar socio
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
            List<Local> locales = new LocalRepositorio().ObtenerLocalesRegistrados();
            ViewData["locales"] = locales;
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

        //Acción filtrar socios según su tipo
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AccionFiltrarSocioPorTipo(string? tipoSocio)
        {
            List<Socio> sociosFiltrados = new List<Socio>();

            if (string.IsNullOrEmpty(tipoSocio))
            {
                ModelState.AddModelError("", "Debe seleccionar un tipo de socio.");
            }
            else if (ModelState.IsValid)
            {
                switch (tipoSocio)
                {
                    case "básico":

                    case "estandar":

                    case "premium":

                        sociosFiltrados = new SocioRepositorio().ObtenerSociosSegunTipo(tipoSocio);
                        return View("GestionandoSocio", sociosFiltrados);

                    default:
                        return NotFound();
                }
            }

            List<Socio> socios = new SocioRepositorio().ObtenerSociosRegistrados();
            return View("GestionandoSocio", socios);
        }

    }
}
