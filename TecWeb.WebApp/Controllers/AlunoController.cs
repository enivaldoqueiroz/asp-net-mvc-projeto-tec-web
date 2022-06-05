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
    public class AlunoController : Controller
    {
        // GET: Aluno
        public ActionResult Index()
        {
            SqlConnection minhaConexao = new SqlConnection(ConfigurationManager.ConnectionStrings["minhaConexao"].ConnectionString);

            minhaConexao.Open();

            string select = "SELECT * FROM [TecWeb].[dbo].[Aluno]";
            SqlCommand selectCommand = new SqlCommand(select, minhaConexao);
            SqlDataReader sqlRead = selectCommand.ExecuteReader();

            List<AlunoModel> alunoModels = new List<AlunoModel>();

            while (sqlRead.Read())
            {
                alunoModels.Add(new AlunoModel(int.Parse(sqlRead["IdAluno"].ToString())
                                              ,sqlRead["Nome"].ToString()
                                              ,int.Parse(sqlRead["RA"].ToString())
                                              ,Convert.ToDateTime(sqlRead["DataNascimento"].ToString())));
            }

            return View(alunoModels);
        }
    }
}