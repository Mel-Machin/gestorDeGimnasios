using gestorDeGimnasios.Models;
using gestorDeGimnasios.Models.DataObjets.DAO;
using Microsoft.AspNetCore.Mvc;

namespace gestorDeGimnasios.Controllers
{
    public class GestionarMaquinaController : Controller{

        //Vista principal de Gestion de Maquinas 
        public ActionResult GestionandoMaquina()
        {
            List<Maquina> maquinas = new MaquinaRepositorio().obtenerMaquinasRegistradas();
            ViewData["TituloLista"] = "Lista de maquinas:";
            return View(maquinas);
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
                ViewData["TituloLista"] = "Lista de maquinas del local "+ idLocal;
                return View("GestionandoMaquina", maquinasFiltradas); // Devuelve la vista GestionandoMaquina con las máquinas filtradas por local.

            }
            ViewData["TituloLista"] = "Lista de maquinas:";
            List<Maquina> maquinas = new MaquinaRepositorio().obtenerMaquinasRegistradas();

            return View("GestionandoMaquina", maquinas); // Devuelve la vista gestionandoMaquina con todas las maquinas.
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AccionOrdenarPorFecha(String opcion)
        {
            if (ModelState.IsValid)
            {

                List<Maquina> maquinasFiltradas = new MaquinaRepositorio().ordenarMaquinasPorFechaCompra(opcion);
                ViewData["TituloLista"] = "Lista de maquinas ordenadas de manera "+ (opcion == "Desc" ? "descendente." : "ascendente."); ;
                return View("GestionandoMaquina", maquinasFiltradas); // Devuelve la vista GestionandoMaquina con las máquinas filtradas (ordenadas).

            }
            List<Maquina> maquinas = new MaquinaRepositorio().obtenerMaquinasRegistradas();
            ViewData["TituloLista"] = "Lista de maquinas:";
            return View("GestionandoMaquina", maquinas); // Devuelve la vista gestionandoMaquina con todas las maquinas.
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CalcularVidaUtil(int idMaquina){ 
            if (ModelState.IsValid){
                int vidaUtilRestante = new MaquinaRepositorio().calcularVidaUtilRestante(idMaquina);
                ViewData["VidaUtilRestante_" + idMaquina] = vidaUtilRestante;
            }  
                // Vuelve a cargar la lista de máquinas y la vista principal
                List<Maquina> maquinas = new MaquinaRepositorio().obtenerMaquinasRegistradas();
                return View("GestionandoMaquina", maquinas);
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

    }
}
