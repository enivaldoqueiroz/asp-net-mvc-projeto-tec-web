using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TecWeb.WebApp.Models
{
    public class DisciplinaModel
    {
        public int IdDisciplina { get; set; }
        public int IdAluno { get; set; }
        public string Nome { get; set; }
        public string Semestre { get; set; }
        public string Curso { get; set; }
        public List<AlunoModel> Alunos { get; set; }

        public DisciplinaModel() { }

        public DisciplinaModel(int idDisciplina, int idAluno, string nome, string semestre, string curso)
        {
            IdDisciplina = idDisciplina;
            IdAluno = idAluno;
            Nome = nome;
            Semestre = semestre;
            Curso = curso;
            Alunos = AlunoModel.ListarAlunosPelaDisciplina(idDisciplina);
        }

        public DisciplinaModel(int idDisciplina, string nome, string semestre, string curso)
        {
            IdDisciplina = idDisciplina;
            Nome = nome;
            Semestre = semestre;
            Curso = curso;
            Alunos = AlunoModel.ListarAlunosPelaDisciplina(idDisciplina);
        }

        public static List<DisciplinaModel> listarDisciplinasPeloAluno(int idAluno)
        {
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

            return disciplinaModels;
        }

        public static List<DisciplinaModel> listarDisciplinas()
        {
            List<DisciplinaModel> disciplinaModels = new List<DisciplinaModel>();


            SqlConnection minhaConexao = new SqlConnection(ConfigurationManager.ConnectionStrings["minhaConexao"].ConnectionString);

            minhaConexao.Open();

            string select = "SELECT * FROM[TecWeb].[dbo].[Disciplina]";
            SqlCommand selectCommand = new SqlCommand(select, minhaConexao);
            SqlDataReader sqlRead = selectCommand.ExecuteReader();

            while (sqlRead.Read())
            {
                disciplinaModels.Add(new DisciplinaModel(int.Parse(sqlRead["IdDisciplina"].ToString())
                                              ,sqlRead["Nome"].ToString()
                                              ,sqlRead["Semestre"].ToString()
                                              ,sqlRead["Curso"].ToString()));
            }

            return disciplinaModels;
        }

        public static string novaDisciplina(string nome, string semestre, string curso)
        {

            SqlConnection minhaConexao = new SqlConnection(ConfigurationManager.ConnectionStrings["minhaConexao"].ConnectionString);

            minhaConexao.Open();

            string insert = string.Format("INSERT INTO Disciplina (Nome, Semestre, Curso) VALUES ( '{0}', '{1}', '{2}')", nome, semestre, curso);
            SqlCommand selectCommand = new SqlCommand(insert, minhaConexao);
            selectCommand.ExecuteNonQuery();

            return "Sucesso";
        }

        public static string excluirVinculoDisciplinaAluno(int idAluno, int idDisciplina)
        {

            SqlConnection minhaConexao = new SqlConnection(ConfigurationManager.ConnectionStrings["minhaConexao"].ConnectionString);

            minhaConexao.Open();

            string delete = string.Format("DELETE FROM [dbo].[AlunoDisciplina] WHERE idAluno = {0} AND idDisciplina = {1}", idAluno, idDisciplina);
            SqlCommand selectCommand = new SqlCommand(delete, minhaConexao);
            selectCommand.ExecuteNonQuery();

            return "Sucesso";
        }
    }
}