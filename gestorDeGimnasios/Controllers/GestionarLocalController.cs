using gestorDeGimnasios.Models;
using gestorDeGimnasios.Models.DataObjets.DAO;
using Microsoft.AspNetCore.Mvc;

namespace gestorDeGimnasios.Controllers
{
    public class GestionarLocalController : Controller
    {
        
        // Vista principal de Gestion de locales
        public ActionResult GestionandoLocal() { 
            List<Local> locales = new LocalRepositorio().obtenerLocalesRegistrados();
            return View(locales);
        }


        //Vista de registrar local
        public ActionResult RegistrarLocal() { 
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AccionRegistrarLocal(Local local)
        {
            if (ModelState.IsValid) { 
                bool resultado = new LocalRepositorio().registrarLocal(local);
                if (resultado)
                {
                    return RedirectToAction("GestionandoLocal");
                }
                else
                {
                    ModelState.AddModelError("","Error al registrar el local.");
                }
            }
            return View(local);
        }

        // Vista de editar local
        public ActionResult EditarLocal(int idLocal)
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
        public ActionResult AccionEditarLocal(Local local) {
            if (!ModelState.IsValid) {
                bool resultado = new LocalRepositorio().modificarLocal(local, local.IdLocal);
                if (resultado) { 
                    return RedirectToAction("GestionandoLocal");
                }
            }
            return View(local);
        }


        //Vista de eliminar local
        public ActionResult EliminarLocal(int idLocal) {
            if (idLocal != 0) {
                Local local = new LocalRepositorio().ObtenerLocal(idLocal);
                return View(local);
            }else{
                return NotFound();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AccionEliminarLocal(Local local) {
            if (!ModelState.IsValid)
            {
                bool resultado = new LocalRepositorio().eliminarLocal(local.IdLocal);
                if (resultado)
                {
                    return RedirectToAction("GestionandoLocal");
                }
            }
            return View(local);
        }


    }
}
