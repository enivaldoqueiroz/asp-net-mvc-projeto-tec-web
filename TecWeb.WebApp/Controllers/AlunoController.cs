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
            List<AlunoModel> alunoModels = AlunoModel.ListarAlunos();
                        
            return View(alunoModels);
        }
    }
}