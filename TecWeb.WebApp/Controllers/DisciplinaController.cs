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
        [HttpGet]
        public ActionResult Index(int idAluno, string nomeAluno)
        {
            ViewBag.idAluno = idAluno;
            ViewBag.NomeAluno = nomeAluno;
            List<DisciplinaModel> disciplinaModels = DisciplinaModel.listarDisciplinasPeloAluno(idAluno);

            return PartialView(disciplinaModels);
        }

        [HttpPost]
        public ActionResult Index(int idAluno, int idDisciplina)
        {
            string resultado = DisciplinaModel.excluirVinculoDisciplinaAluno(idAluno, idDisciplina);
            return View(resultado);
        }

        public ActionResult Disciplinas()
        {
            List<DisciplinaModel> disciplinaModels = DisciplinaModel.listarDisciplinas();
            return View(disciplinaModels);
        }

        public ActionResult novaDisciplina()
        {
            return View();
        }

        [HttpPost]
        public ActionResult novaDisciplina(string Nome, string Semestre, string Curso)
        {
            string sucesso = DisciplinaModel.novaDisciplina(Nome, Semestre, Curso);
            ViewBag.sucesso = sucesso;

            return View();
        }
    }
}