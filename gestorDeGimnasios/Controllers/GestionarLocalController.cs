using gestorDeGimnasios.Models;
using gestorDeGimnasios.Models.DataObjets.DAO;
using Microsoft.AspNetCore.Mvc;

namespace gestorDeGimnasios.Controllers
{
    public class GestionarLocalController : Controller
    {

        // Vista principal de Gestion de locales
        public ActionResult GestionandoLocal()
        {
            List<Local> locales = new LocalRepositorio().ObtenerLocalesRegistrados();
            return View(locales);
        }
        public ActionResult TiposDeMaquinasLocal(int idLocal)
        {
            ViewData["idLocaL"] = idLocal;
            List<TipoMaquina> tiposMaquinas= new TipoMaquinaRepositorio().ObtenerTipoMaquinaLocalCantidad(idLocal);
           return View(tiposMaquinas);
        }


        //Vista de registrar local
        public ActionResult RegistrarLocal()
        {

            List<Responsable> responsables = new ResponsableReposiotorio().ObtenerResponsablesRegistrados();
            ViewData["responsables"] = responsables;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AccionRegistrarLocal(Local local){
            if (ModelState.IsValid){
                if (!(new LocalRepositorio().ExisteResponsableLocal(local.IdResponsable))){
                    bool resultado = new LocalRepositorio().RegistrarLocal(local);
                    if (resultado)
                    {
                        return RedirectToAction("GestionandoLocal");
                    }
                }else{
                    List<Responsable> responsables = new ResponsableReposiotorio().ObtenerResponsablesRegistrados();
                    ViewData["responsables"] = responsables;
                    ModelState.AddModelError("", "Error al registrar local, el responsable seleccionado ya tiene un local asignado.");
                    return View("RegistrarLocal");
                }
            }
            return View(local);
        }


        // Vista de editar local
        public ActionResult EditarLocal(int idLocal)
        {
            if (idLocal != 0)
            {
                List<Responsable> responsables = new ResponsableReposiotorio().ObtenerResponsablesRegistrados();
                ViewData["responsables"] = responsables;
                Local local = new LocalRepositorio().ObtenerLocal(idLocal);
                return View(local);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AccionEditarLocal(Local local)
        {
            if (ModelState.IsValid)
            {
                if (!(new LocalRepositorio().ExisteResponsableLocal(local.IdResponsable)))
                {
                    bool resultado = new LocalRepositorio().ModificarLocal(local, local.IdLocal);
                    if (resultado)
                    {
                        return RedirectToAction("GestionandoLocal");
                    }
                }else
                {
                    List<Responsable> responsables = new ResponsableReposiotorio().ObtenerResponsablesRegistrados();
                    ViewData["responsables"] = responsables;
                    ModelState.AddModelError("", "Error al modificar el local, el responsable seleccionado ya tiene un local asignado.");
                    return View("EditarLocal", local);
                }
            }
            return View(local);
        }


        //Vista de eliminar local
        public ActionResult EliminarLocal(int idLocal)
        {
            if (idLocal != 0)
            {
                Local local = new LocalRepositorio().ObtenerLocal(idLocal);
                return View(local);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AccionEliminarLocal(Local local)
        {
            if (ModelState.IsValid)
            {
                bool resultado = new LocalRepositorio().EliminarLocal(local.IdLocal);
                if (resultado)
                {
                    return RedirectToAction("GestionandoLocal");
                }
            }
            return View(local);
        }

        
    }
}
