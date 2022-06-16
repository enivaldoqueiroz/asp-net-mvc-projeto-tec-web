using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TecWeb.WebApp.Models
{
    public class AlunoModel
    {
        public int IdAluno { get; set; }
        public string Nome { get; set; }
        public int RA { get; set; }
        public DateTime DataNascimento { get; set; }

        public AlunoModel() { }

        public AlunoModel(int idAluno, string nome, int ra, DateTime dataNasc)
        {
            IdAluno = idAluno;
            Nome = nome;
            RA = ra;
            DataNascimento = dataNasc;
        }

        public static List<AlunoModel> ListarAlunos()
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
                                              , sqlRead["Nome"].ToString()
                                              , int.Parse(sqlRead["RA"].ToString())
                                              , Convert.ToDateTime(sqlRead["DataNascimento"].ToString())));
            }

            return alunoModels;
        }

        public static List<AlunoModel> ListarAlunosPelaDisciplina(int idDisciplina)
        {
            SqlConnection minhaConexao = new SqlConnection(ConfigurationManager.ConnectionStrings["minhaConexao"].ConnectionString);

            minhaConexao.Open();

            string select = "SELECT * FROM [TecWeb].[dbo].[Aluno] INNER JOIN [TecWeb].[dbo].AlunoDisciplina ON Aluno.IdAluno = AlunoDisciplina.IdAluno WHERE AlunoDisciplina.idDisciplina =" + idDisciplina;
            SqlCommand selectCommand = new SqlCommand(select, minhaConexao);
            SqlDataReader sqlRead = selectCommand.ExecuteReader();

            List<AlunoModel> alunoModels = new List<AlunoModel>();

            while (sqlRead.Read())
            {
                alunoModels.Add(new AlunoModel(int.Parse(sqlRead["IdAluno"].ToString())
                                              , sqlRead["Nome"].ToString()
                                              , int.Parse(sqlRead["RA"].ToString())
                                              , Convert.ToDateTime(sqlRead["DataNascimento"].ToString())));
            }

            return alunoModels;
        }
    }
}