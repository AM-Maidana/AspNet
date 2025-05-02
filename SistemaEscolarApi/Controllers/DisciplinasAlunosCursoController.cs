using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SistemaEscolarApi.Models;
using SistemaEscolarApi.DTO;
using SistemaEscolarApi.DB;
using Microsoft.AspNetCore.Mvc;


namespace SistemaEscolarApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DisciplinasAlunosCursosController : ControllerBase
    {
        private readonly AppDbContext _context; // Injeção de dependência do contexto do banco de dados

        public DisciplinasAlunosCursosController(AppDbContext context) // Contrutor que recebe o contexto do banco
        {
            _context = context; // Inicializa o contexto do banco de dados
        }

      [HttpGet]
public async Task<ActionResult<IEnumerable<DisciplinaAlunoCursoDTO>>> Get()
{
    var registros = await _context.DisciplinasAlunosCursos
        .Include(d => d.AlunoNome)
        .Include(d => d.Curso)
        .Include(d => d.Disciplina)
        .Select(d => new DisciplinaAlunoCursoDTO
        {
            ID = d.AlunoID + d.CursoID + d.DisciplinaID,
            AlunoID = d.AlunoID,
            AlunoNome = d.AlunoNome.Nome, // Supondo que a classe Aluno tenha a propriedade Nome
            CursoID = d.CursoID,
            CursoNome = d.Curso.Descricao, // Supondo que a classe Curso tenha Descricao
            DisciplinaID = d.DisciplinaID,
            DisciplinaNome = d.Disciplina.Descricao // Supondo que a classe Disciplina tenha Descricao
        })
        .ToListAsync();

    return Ok(registros);
}


        [HttpPost]
        public async Task<ActionResult> Post([FromBody] DisciplinaAlunoCursoDTO disciplinaAlunoCursoDTO)
        {
            var entidade = new DisciplinaAlunoCurso
            {
                AlunoID = disciplinaAlunoCursoDTO.AlunoID,
                CursoID = disciplinaAlunoCursoDTO.CursoID,
                DisciplinaID = disciplinaAlunoCursoDTO.DisciplinaID
            };
            _context.DisciplinasAlunosCursos.Add(entidade);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] DisciplinaAlunoCursoDTO disciplinaAlunoCursoDTO)
        {
            var entidade = await _context.DisciplinasAlunosCursos.FindAsync(id);
            if (entidade == null)
            {
                return NotFound();
            }

            entidade.AlunoID = disciplinaAlunoCursoDTO.AlunoID;
            entidade.CursoID = disciplinaAlunoCursoDTO.CursoID;
            entidade.DisciplinaID = disciplinaAlunoCursoDTO.DisciplinaID;

            _context.DisciplinasAlunosCursos.Update(entidade);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var entidade = await _context.DisciplinasAlunosCursos.FindAsync(id);
            if (entidade == null)
            {
                return NotFound();
            }

            _context.DisciplinasAlunosCursos.Remove(entidade);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<DisciplinaAlunoCursoDTO>> GetById(int id)
        {
            var relacoes = await _context.DisciplinasAlunosCursos
                .Include(d => d.AlunoNome)
                .Include(d => d.Curso)
                .Include(d => d.Disciplina)
                .ToListAsync();

            var relacao = relacoes.FirstOrDefault(r => r.AlunoID + r.CursoID + r.DisciplinaID == id);
            if (relacao == null)
            {
                return NotFound("relação nao enontrada");
            }
            
            var dto = new DisciplinaAlunoCursoDTO
            {
                ID = relacao.AlunoID + relacao.CursoID + relacao.DisciplinaID,
                AlunoID = relacao.AlunoID,
                AlunoNome = relacao.AlunoNome.Nome, // Supondo que a classe Aluno tenha a propriedade Nome
                CursoID = relacao.CursoID,
                CursoNome = relacao.Curso.Descricao, // Supondo que a classe Curso tenha Descricao
                DisciplinaID = relacao.DisciplinaID,
                DisciplinaNome = relacao.Disciplina.Descricao // Supondo que a classe Disciplina tenha Descricao
            };

            return Ok(dto);
        }
    }
}