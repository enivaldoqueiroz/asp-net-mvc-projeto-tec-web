using System;
using System.Collections.Generic;
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

        internal static List<DisciplinaModel> Where(Func<object, object> p)
        {
            throw new NotImplementedException();
        }
    }
}