using gestorDeGimnasios.Models;
using gestorDeGimnasios.Models.DataObjets.DAO;
using Microsoft.AspNetCore.Mvc;

namespace gestorDeGimnasios.Controllers{
    public class GestionarTipoMaquinaController: Controller{

        /*
        public bool registrarTipoMaquina(TipoMaquina tipoMaquina) { 
            return new TipoMaquinaRepositorio().RegistrarTipoMaquina(tipoMaquina);
        }
        public bool eliminarTipoMaquina(int idTipoMaquina) {
            return new TipoMaquinaRepositorio().EliminarTipoMaquina(idTipoMaquina);
        }
        public bool modificarTipoMaquina(TipoMaquina tipoMaquina, int idTipoMaquina) {
            return new TipoMaquinaRepositorio().ModificarTipoMaquina(tipoMaquina, idTipoMaquina); 
        }
        */


        public ActionResult GestionandoTipoMaquina()
        {
            List<TipoMaquina> tiposMaquinas = new TipoMaquinaRepositorio().ObtenerTiposMaquinasRegistradas();
            return View(tiposMaquinas);
        }


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
