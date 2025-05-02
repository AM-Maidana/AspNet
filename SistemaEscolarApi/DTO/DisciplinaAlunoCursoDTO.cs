using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaEscolarApi.DTO
{
    public class DisciplinaAlunoCursoDTO
{
    public int ID { get; set; }
    public int AlunoID { get; set; }
    public string AlunoNome { get; set; }

    public int CursoID { get; set; }
    public string CursoNome { get; set; }

    public int DisciplinaID { get; set; }
    public string DisciplinaNome { get; set; }
}

}