using gestorDeGimnasios.Models;
using gestorDeGimnasios.Models.DataObjets.DAO;
using Microsoft.AspNetCore.Mvc;

namespace gestorDeGimnasios.Controllers{
    public class GestionarTipoMaquinaController: Controller{

        //Vista principal de gestionando tipo maquina
        public ActionResult GestionandoTipoMaquina()
        {
            List<TipoMaquina> tiposMaquinas = new TipoMaquinaRepositorio().ObtenerTiposMaquinasRegistradas();
            return View(tiposMaquinas);
        }

        //Vista de registrar maquina
        public ActionResult RegistrarTipoMaquina()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AccionRegistrarTipoMaquina(TipoMaquina tipoMaquina)
        {
            if (ModelState.IsValid)
            {
                bool resultado = new TipoMaquinaRepositorio().RegistrarTipoMaquina(tipoMaquina);
                if (resultado)
                {
                    return RedirectToAction("GestionandoTipoMaquina");
                }
                else
                {
                    ModelState.AddModelError("", "Error al registrar la máquina.");
                }
            }
            return View(tipoMaquina);
        }

        //Vista editar tipo maquina
        public ActionResult EditarTipoMaquina(int idTipoMaquina){
            if (idTipoMaquina != 0){
                TipoMaquina tipoMaquina = new TipoMaquinaRepositorio().ObtenerTipoMaquina(idTipoMaquina);
                return View(tipoMaquina);
            }else{
                return View();
            }
              
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AccionEditarTipoMaquina(TipoMaquina tipoMaquina)
        {
            if (ModelState.IsValid)
            {
                bool resultado = new TipoMaquinaRepositorio().ModificarTipoMaquina(tipoMaquina, tipoMaquina.IdTipoMaquina);
                if (resultado)
                {
                    return RedirectToAction("GestionandoTipoMaquina");
                }
            }
            return View(tipoMaquina);
        }

        //Vista eliminar tipo maquina
        public ActionResult EliminarTipoMaquina(int idTipoMaquina){ 
            if(idTipoMaquina != 0){
                TipoMaquina tipoMaquina = new TipoMaquinaRepositorio().ObtenerTipoMaquina(idTipoMaquina);
                return View(tipoMaquina);
            }else{
                  
                return NotFound();
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AccionEliminarTipoMaquina(TipoMaquina tipoMaquina) {
            if (ModelState.IsValid)
            {
                bool resultado = new TipoMaquinaRepositorio().EliminarTipoMaquina(tipoMaquina.IdTipoMaquina);
                if (resultado)
                {
                    return RedirectToAction("GestionandoTipoMaquina");
                }
            }
            return View(tipoMaquina);
        }

        
    }
}
