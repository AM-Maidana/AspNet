using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaEscolarApi.Models
{
    public class Curso
    {
        public int ID { get; set; }
        public string Descricao { get; set; }
        
        public ICollection<Aluno> Alunos { get; set; } = [];
        public ICollection<Disciplina> Disciplinas { get; set; } = [];
    }
}