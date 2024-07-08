using gestorDeGimnasios.Models;
using gestorDeGimnasios.Models.DataObjets.DAO;
using Microsoft.AspNetCore.Mvc;

namespace gestorDeGimnasios.Controllers
{
    public class GestionarResponsableController : Controller
    {

        private readonly IHttpContextAccessor context;

        //Constructor de la clase HomeController  
        public GestionarResponsableController(IHttpContextAccessor context)
        {
            this.context = context;
        }


        //Vista principal de Gestion de responsables 
        public ActionResult GestionandoResponsable()
        {
            if (this.context.HttpContext.Session.GetString("tipoUsuario") == "administrador")
            {
                List<Responsable> responsables = new ResponsableReposiotorio().ObtenerResponsablesRegistrados();
                return View(responsables);
            }
            else
            {
                return RedirectToAction("index", "Home");
            }

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
                Responsable responsableAEditar = new ResponsableReposiotorio().ObtenerResponsable(responsable.IdResponsable);

                if (!(new ResponsableReposiotorio().ExisteUsuarioResponsable(responsable.NombreUsuario)) || responsable.NombreUsuario == responsableAEditar.NombreUsuario)
                {
                    bool resultado = new ResponsableReposiotorio().ModificarResponsable(responsable);
                    if (resultado)
                    {
                        return RedirectToAction("GestionandoResponsable");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Error al modificar el responsable, el nombre de usuario ya pertenece a un responsable.");
                    return View("EditarResponsable", responsable);
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
                if (!(new ResponsableReposiotorio().ExisteUsuarioResponsable(responsable.NombreUsuario)))
                {
                    bool resultado = new ResponsableReposiotorio().RegistrarResponsable(responsable);
                    if (resultado)
                    {
                        return RedirectToAction("GestionandoResponsable");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Error al crear el responsable, el nombre de usuario ya pertenece a un responsable.");
                    return View("RegistrarResponsable");
                }
            }
            return View(responsable);
        }
    }
}
