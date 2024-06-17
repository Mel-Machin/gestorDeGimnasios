using gestorDeGimnasios.Models;
using gestorDeGimnasios.Models.DataObjets.DAO;
using Microsoft.AspNetCore.Mvc;

namespace gestorDeGimnasios.Controllers
{
    public class GestionarMaquinaController : Controller
    {
        /* public List<Maquina> ObtenerMaquinasPorLocal(Local local) { 
            return new MaquinaRepositorio().ObtenerMaquinasPorLocal(local); 
        }
        public List<Maquina> OrdenarMaquinasPorFechaCompra(string orden) {
            return new MaquinaRepositorio().ordenarMaquinasPorFechaCompra(orden);
        }
        public int CalcularVidaUtilRestante(int idMaquina){
            return new MaquinaRepositorio().calcularVidaUtilRestante(idMaquina);
        }*/

        //Vista principal de Gestion de Maquina 
        public ActionResult GestionandoMaquina()
        {
            List<Maquina> maquinas = new MaquinaRepositorio().obtenerMaquinasRegistradas();
            ViewData["TituloLista"] = "Listando todas las maquinas";
            return View(maquinas);
        }


        //Vista de editar maquina
        public ActionResult EditarMaquina(int idMaquina)
        {
            if (idMaquina != 0)
            {
                Maquina maquina = new MaquinaRepositorio().obtenerMaquina(idMaquina);
                return View(maquina);
            }
            else
            {
                return NotFound();

            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AccionEditarMaquina(Maquina maquina)
        {
            if (ModelState.IsValid)
            {
                bool resultado = new MaquinaRepositorio().modificarMaquina(maquina, maquina.IdMaquina);
                if (resultado)
                {
                    return RedirectToAction("GestionandoMaquina");
                }
            }
            return View(maquina);
        }


        //Vista de eliminar maquina
        public ActionResult EliminarMaquina(int idMaquina)
        {
            if (idMaquina != 0)
            {
                Maquina maquina = new MaquinaRepositorio().obtenerMaquina(idMaquina);
                return View(maquina);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AccionEliminarMaquina(Maquina maquina)
        {
            if (ModelState.IsValid)
            {
                bool resultado = new MaquinaRepositorio().eliminarMaquina(maquina.IdMaquina);
                if (resultado)
                {
                    return RedirectToAction("GestionandoMaquina");
                }
            }
            return View(maquina);
        }


        //Vista de registrar maquina
        public ActionResult RegistrarMaquina()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AccionRegistrarMaquina(Maquina maquina)
        {
            if (ModelState.IsValid)
            {
                bool resultado = new MaquinaRepositorio().registrarMaquina(maquina);
                if (resultado)
                {
                    return RedirectToAction("GestionandoMaquina");
                }
                else
                {
                    ModelState.AddModelError("", "Error al registrar la máquina.");
                }
            }
            return View(maquina);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AccionFiltrarPorLocal(int idLocal)
        {
            if (ModelState.IsValid)
            {
                Local local = new Local();
                local.IdLocal=idLocal;
                List<Maquina> maquinasFiltradas = new MaquinaRepositorio().ObtenerMaquinasPorLocal(local);
                ViewData["TituloLista"] = "Listando todas las maquinas del local "+ idLocal;
                return View("GestionandoMaquina", maquinasFiltradas); // Devuelve la vista GestionandoMaquina con las máquinas filtradas

            }
            ViewData["TituloLista"] = "Listando todas las maquinas";
            List<Maquina> maquinas = new MaquinaRepositorio().obtenerMaquinasRegistradas();

            return View("GestionandoMaquina", maquinas);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AccionOrdenarFecha(String opcion)
        {
            if (ModelState.IsValid)
            {

                List<Maquina> maquinasFiltradas = new MaquinaRepositorio().ordenarMaquinasPorFechaCompra(opcion);
                ViewData["TituloLista"] = "Listando todas las maquinas en orden "+ (opcion == "Desc" ? "descendente" : "scendente"); ;
                return View("GestionandoMaquina", maquinasFiltradas); // Devuelve la vista GestionandoMaquina con las máquinas filtradas

            }
            List<Maquina> maquinas = new MaquinaRepositorio().obtenerMaquinasRegistradas();
            ViewData["TituloLista"] = "Listando todas las maquinas";
            return View("GestionandoMaquina", maquinas);
        }
    }
}
