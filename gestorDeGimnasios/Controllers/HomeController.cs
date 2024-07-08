using gestorDeGimnasios.Models;
using gestorDeGimnasios.Models.DataObjets.DAO;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Reflection;

namespace gestorDeGimnasios.Controllers
{

    public class HomeController : Controller
    {

        private readonly IHttpContextAccessor context;

        //Constructor de la clase HomeController  
        public HomeController(IHttpContextAccessor context)
        {
            this.context = context;
        }


        public ActionResult Index()
        {
            return View();
        }


        public ActionResult IniciarSesion()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AccionIniciarSesion(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                if (usuario.IsTipoUsuario("responsable") && this.AutentificarSesionResponsable(usuario))
                {
                    this.context.HttpContext.Session.SetString("tipoUsuario", "responsable");
                 
                }else if (usuario.IsTipoUsuario("administrador") && this.AutentificarSesionAdministrador(usuario))
                {
                    this.context.HttpContext.Session.SetString("tipoUsuario", "administrador");

                }
                else
                {
                    ModelState.AddModelError("", "Error al iniciar sesion vuelva a intentarlo.");
                    return View("iniciarSesion");
                }
                return RedirectToAction("index", "Home");
               
            }


            return View("IniciarSesion");
        }

        private bool AutentificarSesionResponsable (Usuario usuario){
            SesionRepositorio sesionRepositorio = new SesionRepositorio();
            if (sesionRepositorio.IniciarSesion(usuario))
            {
                return true;
            }
            else
            {
                return false;
               
            }
        }

        private bool AutentificarSesionAdministrador(Usuario usuario)
        {
            if (usuario.NombreUsuario=="admin" && usuario.Contrasenia=="admin")
            {
                return true;
            }
            else
            {
                return false;

            }
        }


        public ActionResult AccionCerrarSesion()
        {
       
             this.context.HttpContext.Session.SetString("tipoUsuario", "");
             return RedirectToAction("Index", "Home");
        }
    }
}
