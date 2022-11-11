using MineCursos.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MineCursos.Controllers
{
    public class DisciplinasController : Controller
    {
        bdCursosEntities bd = new bdCursosEntities();
        // GET: Disciplinas
        public ActionResult Index()
        {

            if (Session["MyCurso"] != null)
            {

                ViewBag.qtdDisciplinas = bd.Disciplinas.ToList().Count();



                return View(bd.Disciplinas.ToList());
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
                ViewBag.listaCursos = bd.Cursos.ToList();
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
          
        }


        [HttpPost]
        public ActionResult Criar(string descricao, int curso, int carga)
        {

            if (Session["MyCurso"] != null)
            {

                Disciplinas novodisciplina = new Disciplinas();

                novodisciplina.DISDESCRIACAO = descricao;
                novodisciplina.CURSOID = curso;
                novodisciplina.DISCH = carga;


                bd.Disciplinas.Add(novodisciplina);
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
                Disciplinas Disatualizar = bd.Disciplinas.ToList().Where(x => x.DISID == id).First();
                return View(Disatualizar);

            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }

        [HttpPost]
        public ActionResult Editar(int? id, string descricao, string curso, int carga)
        {

            if (Session["MyCurso"] != null)
            {
                Disciplinas Disciatualizar = bd.Disciplinas.ToList().Where(x => x.DISID == id).First();
                Disciatualizar.DISDESCRIACAO = descricao;
                Disciatualizar.Cursos.CURSODESCRICAO = curso;
                Disciatualizar.DISCH = carga;


                bd.Entry(Disciatualizar).State = EntityState.Modified;

                bd.SaveChanges();
                return RedirectToAction("Index");
                ViewBag.qtdCursos = bd.Cursos.ToList().Count();
                ViewBag.NomeCursos = bd.Cursos.ToList();


                return View(bd.Cursos.ToList());
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

                Disciplinas DisDeletar = bd.Disciplinas.ToList().Where(x => x.DISID == id).First();
                return View(DisDeletar);
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

                Disciplinas DisDeletar = bd.Disciplinas.ToList().Where(x => x.DISID == id).First();
                bd.Disciplinas.Remove(DisDeletar);
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

                Disciplinas DisExibir = bd.Disciplinas.ToList().Where(x => x.DISID == id).First();
                return View(DisExibir);
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
         
        }
    }
}