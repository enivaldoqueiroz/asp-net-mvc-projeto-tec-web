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

        public DisciplinaModel() { }

        public DisciplinaModel(int idDisciplina, int idAluno, string nome, string semestre, string curso)
        {
            IdDisciplina = idDisciplina;
            IdAluno = idAluno;
            Nome = nome;
            Semestre = semestre;
            Curso = curso;
        }

        public DisciplinaModel(int idDisciplina, string nome, string semestre, string curso)
        {
            IdDisciplina = idDisciplina;
            Nome = nome;
            Semestre = semestre;
            Curso = curso;
        }

        public static List<DisciplinaModel> disciplinaModels(int idAluno)
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
    }
}