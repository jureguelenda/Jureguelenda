using MineCursos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MineCursos.Controllers
{
    public class CursoDisciplinaController : Controller
    {
        bdCursosEntities bd = new bdCursosEntities();
        // GET: CursoDisciplina
        public ActionResult Index()
        {

            
            return View(bd.GrupoCursoQuantidadeDisciplina.ToList());
        }

        public ActionResult Teste()
        {
      


            return View();
        }

        public ActionResult DisciplinaporCurso( int? id)
        {



            return View(bd.Disciplinas.ToList().Where(x => x.CURSOID == id));
        }

    }
}