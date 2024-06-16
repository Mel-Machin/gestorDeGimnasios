using gestorDeGimnasios.Models;
using gestorDeGimnasios.Models.DataObjets.DAO;
using Microsoft.AspNetCore.Mvc;

namespace gestorDeGimnasios.Controllers
{
    public class GestionarMaquinaController:Controller
    {
        public bool registrarMaquina(Maquina maquina) {
            return new MaquinaRepositorio().registrarMaquina(maquina); 
        }
   
        public List<Maquina> obtenerMaquinasPorLocal(Local local) { 
            return new MaquinaRepositorio().ObtenerMaquinasPorLocal(local); 
        }
        public List<Maquina> ordenarMaquinasPorFechaCompra(string orden) {
            return new MaquinaRepositorio().ordenarMaquinasPorFechaCompra(orden);
        }
        public int calcularVidaUtilRestante(int idMaquina)
        {
            return new MaquinaRepositorio().calcularVidaUtilRestante(idMaquina);
        }

        public ActionResult EditarMaquina(int id)
        {

            if (id != 0)
            {
                Maquina maquina = new MaquinaRepositorio().obtenerMaquina(id);
                return View(maquina);
            }
            else
            {
                return NotFound();

            }



        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditarMaquina(Maquina maquina)
        {
            if (ModelState.IsValid)
            {
                bool resultado = new MaquinaRepositorio().modificarMaquina(maquina, maquina.IdMaquina);
                if (resultado)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(maquina);
        }

        public ActionResult Index()
        {
            List<Maquina> maquinas = new MaquinaRepositorio().obtenerMaquinasRegistradas();
            return View(maquinas);
        }

        public ActionResult EliminarMaquina(int id)
        {

            if (id != 0)
            {
                Maquina maquina = new MaquinaRepositorio().obtenerMaquina(id);
                return View(maquina);
            }
            else
            {
                return NotFound();

            }



        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EliminarMaquina(Maquina maquina)
        {
            if (ModelState.IsValid)
            {
                bool resultado = new MaquinaRepositorio().eliminarMaquina(maquina.IdMaquina);
                if (resultado)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(maquina);
        }


    }




}
