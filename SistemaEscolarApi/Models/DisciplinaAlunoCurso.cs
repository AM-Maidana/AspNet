using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaEscolarApi.Models
{
    public class DisciplinaAlunoCurso
    {
       public int AlunoID { get; set; } 
       public int DisciplinaID { get; set; }
       public int CursoID { get; set; }
    }
}