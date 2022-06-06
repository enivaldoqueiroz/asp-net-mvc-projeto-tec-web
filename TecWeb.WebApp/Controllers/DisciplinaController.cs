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
            List<DisciplinaModel> disciplinaModels = new List<DisciplinaModel>();


            SqlConnection minhaConexao = new SqlConnection(ConfigurationManager.ConnectionStrings["minhaConexao"].ConnectionString);

            minhaConexao.Open();

            string select = "SELECT * FROM[TecWeb].[dbo].[Disciplina] INNER JOIN AlunoDisciplina ON Disciplina.IdDisciplina =  AlunoDisciplina.idDisciplina WHERE AlunoDisciplina.idAluno = " + idAluno;
            SqlCommand selectCommand = new SqlCommand(select, minhaConexao);
            SqlDataReader sqlRead = selectCommand.ExecuteReader();

            while (sqlRead.Read())
            {
                disciplinaModels.Add(new DisciplinaModel(int.Parse(sqlRead["IdDisciplina"].ToString())
                                              , idAluno
                                              , sqlRead["Nome"].ToString()
                                              , sqlRead["Semestre"].ToString()
                                              , sqlRead["Curso"].ToString()));
            }

            return View(disciplinaModels);
        }
    }
}