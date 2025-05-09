using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaEscolarApi.DTO
{
public class AlunoCreateDTO
{
    public string Nome { get; set; }
    public int CursoId { get; set; }
    public string? Curso { get; set; } // Opcional: só usado para exibição
}
public class AlunoReadDTO
{
    public int ID { get; set; }
    public string Nome { get; set; }
    public int CursoId { get; set; }
    public string? Curso { get; set; } // Opcional: só usado para exibição
}
}