using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaEscolarApi.Models
{
    public class Aluno
    {
        public int Id {get; set;}
        public string Nome {get; set;}
        public int CursoId {get; set;}
        public Curso Curso {get; set;}

        // public Icollection<DisciplinaAlunoCurso> DisciplinasAlunosCursos {get; set;} = new List<DisciplinaAlunoCurso>();//Coleção dessa relação de disciplinas que o aluno está matriculado
        public ICollection<DisciplinaAlunoCurso> DisciplinasAlunosCursos {get; set;} = [];
    }
}