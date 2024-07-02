using gestorDeGimnasios.Models;
using gestorDeGimnasios.Models.DataObjets.DAO;
using Microsoft.AspNetCore.Mvc;

namespace gestorDeGimnasios.Controllers
{
    public class GestionarResponsableController : Controller
    {
        //Vista principal de Gestion de responsables 
        public ActionResult GestionandoResponsable()
        {
            List<Responsable> responsables = new ResponsableReposiotorio().ObtenerResponsablesRegistrados();
            return View(responsables);
        }

        //Vista de editar responsable
        public ActionResult EditarResponsable(int idResponsable)
        {
            if (idResponsable != 0)
            {
                Responsable responsable = new ResponsableReposiotorio().ObtenerResponsable(idResponsable);
                return View(responsable);
            }
            else
            {
                return NotFound();

            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AccionEditarResponsable(Responsable responsable)
        {
            if (ModelState.IsValid)
            {
                bool resultado = new ResponsableReposiotorio().ModificarResponsable(responsable, responsable.IdResponsable);
                if (resultado)
                {
                    return RedirectToAction("GestionandoResponsable");
                }
            }
            return View(responsable);
        }


        //Vista de eliminar responsable
        public ActionResult EliminarResponsable(int idResponsable)
        {
            if (idResponsable != 0)
            {
                Responsable responsable = new ResponsableReposiotorio().ObtenerResponsable(idResponsable);
                return View(responsable);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AccionEliminarResponsable(Responsable responsable)
        {
            if (ModelState.IsValid)
            {
                bool resultado = new ResponsableReposiotorio().EliminarResponsable(responsable.IdResponsable);
                if (resultado)
                {
                    return RedirectToAction("GestionandoResponsable");
                }
            }
            return View(responsable);
        }


        //Vista de registrar responsable
        public ActionResult RegistrarResponsable()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AccionRegistrarResponsable(Responsable responsable)
        {
            if (ModelState.IsValid)
            {
                bool resultado = new ResponsableReposiotorio().RegistrarResponsable(responsable);
                if (resultado)
                {
                    return RedirectToAction("GestionandoResponsable");
                }
                else
                {
                    ModelState.AddModelError("", "Error al registrar el responsable.");
                }
            }
            return View(responsable);
        }
    }
}
