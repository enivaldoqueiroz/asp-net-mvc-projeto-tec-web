using System;
using System.Collections.Generic;
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
    }
}