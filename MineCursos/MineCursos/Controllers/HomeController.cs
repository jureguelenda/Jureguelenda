using MineCursos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MineCursos.Controllers
{
    public class HomeController : Controller
    {
        bdCursosEntities bd = new bdCursosEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Projetos()
        {
            return View();
        }

        public ActionResult Erro()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult VerificarLogin(string username, string pass)
        {
          

            foreach (var Item in bd.Colaborador)
            {
                if ( (Item.UsuarioLogin == username) && (Item.UsuarioSenha == pass) )
                {
                    Session["MyCurso"] = "MyCurso";
                    return RedirectToAction("Projetos");

                }

            }
                ViewBag.textoErro = "Login ou senha incorreto";
                return RedirectToAction("Login");
        }

        public ActionResult DashboadCursos()
        {
            if (Session["MyCurso"] != null)
            {
                return View(bd.GrupoCursoQuantidadeDisciplina.ToList());
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }


        }


    }
}