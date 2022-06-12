using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TecWeb.WebApp.Models;

namespace TecWeb.WebApp.Controllers
{
    public class DisciplinaController : Controller
    {
        // GET: Disciplina
        public ActionResult Index(int idAluno, string nomeAluno)
        {
            ViewBag.idAluno = idAluno;
            ViewBag.NomeAluno = nomeAluno;
            List<DisciplinaModel> disciplinaModels = DisciplinaModel.listarDisciplinasPeloAluno(idAluno);

            return PartialView(disciplinaModels);
        }

        public ActionResult Disciplinas()
        {
            List<DisciplinaModel> disciplinaModels = DisciplinaModel.listarDisciplinas();
            return View(disciplinaModels);
        }
    }
}