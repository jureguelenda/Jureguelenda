using MineCursos.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MineCursos.Controllers
{
    public class CursosController : Controller
    {
        bdCursosEntities bd = new bdCursosEntities();
        // GET: Cursos
        public ActionResult Index()
        {
            if (Session["MyCurso"] != null)
            {

                ViewBag.qtdCursos = bd.Cursos.ToList().Count();
                ViewBag.NomeCursos = bd.Cursos.ToList();


                return View(bd.Cursos.ToList());
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }

        }


        public ActionResult Criar()
        {

            if (Session["MyCurso"] != null)
            {

                return View();
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }

        }
       

        [HttpPost]
        public ActionResult Criar(string descricao, string habilidade, string modalidade)
        {
            if (Session["MyCurso"] != null)
            {
                Cursos novocurso = new Cursos();

                novocurso.CURSODESCRICAO = descricao;
                novocurso.CURSOCODHABILIDADE = habilidade;
                novocurso.CURSOMODALIDADE = modalidade;
                Cursos ultimoCurso = bd.Cursos.ToList().Last();
                int ultimoID = ultimoCurso.CURSOID;
                novocurso.CURSOID = ultimoID + 1;


                bd.Cursos.Add(novocurso);
                bd.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }


         
        }






        [HttpGet]
        public ActionResult Editar(int? id)
        {
            if (Session["MyCurso"] != null)
            {


                Cursos Colatualizar = bd.Cursos.ToList().Where(x => x.CURSOID == id).First();
                return View(Colatualizar);
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }

        }

        [HttpPost]
        public ActionResult Editar(int? id, string descricao, string habilidade, string modalidade)
        {
            if (Session["MyCurso"] != null)
            {
                Cursos Cursoatualizar = bd.Cursos.ToList().Where(x => x.CURSOID == id).First();
                Cursoatualizar.CURSODESCRICAO = descricao;
                Cursoatualizar.CURSOCODHABILIDADE = habilidade;
                Cursoatualizar.CURSOMODALIDADE = modalidade;


                bd.Entry(Cursoatualizar).State = EntityState.Modified;

                bd.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }

        

        }

        [HttpGet]
        public ActionResult Deletar(int? id)
        {

            if (Session["MyCurso"] != null)
            {

                Cursos CurDeletar = bd.Cursos.ToList().Where(x => x.CURSOID == id).First();
                return View(CurDeletar);
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }

     
        }

        [HttpPost]
        public ActionResult ConfirmeDelete(int? id)
        {

            if (Session["MyCurso"] != null)
            {

                Cursos CurDeletar = bd.Cursos.ToList().Where(x => x.CURSOID == id).First();
                bd.Cursos.Remove(CurDeletar);
                try
                {
                    bd.SaveChanges();
                }
                catch
                {
                    return RedirectToAction("Erro", "Home");
                }





                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
         
        }
        public ActionResult Exibir(int? id)
        {

            if (Session["MyCurso"] != null)
            {

                Cursos curExibir = bd.Cursos.ToList().Where(x => x.CURSOID == id).First();
                return View(curExibir);
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }

           
        }


    }



 

}