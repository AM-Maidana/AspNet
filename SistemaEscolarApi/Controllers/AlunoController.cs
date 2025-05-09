using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SistemaEscolarApi.Models;
using SistemaEscolarApi.DTO;
using Microsoft.AspNetCore.Mvc;
using SistemaEscolarApi.DB;
using Microsoft.EntityFrameworkCore;



namespace SistemaEscolarApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase

    {
        private readonly AppDbContext _context;

        public AlunoController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AlunoReadDTO>>> GetAlunos()
        {
            var alunos = await _context.Alunos
                .Include(a => a.Curso)
                .Select(a => new AlunoReadDTO
                {

                    ID = a.ID,
                    Nome = a.Nome,
                    Curso = a.Curso.Descricao
                })
                .ToListAsync();

            return Ok(alunos);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] AlunoCreateDTO alunoCreateDTO)
        {
            var curso = await _context.Cursos.FindAsync(alunoCreateDTO.CursoId);
            if (curso == null) return BadRequest(ModelState);


            var aluno = new Aluno { Nome = alunoCreateDTO.Nome, CursoId = curso.ID };
            _context.Alunos.Add(aluno);
            await _context.SaveChangesAsync();

            return Ok(new { mensagem = "Aluno cadastrado com sucesso" });
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] AlunoCreateDTO alunoDTO)
        {
            var aluno = await _context.Alunos.FindAsync(id);
            if (aluno == null) return NotFound("Aluno não encontrado");
            var Curso = await _context.Cursos.FirstOrDefaultAsync(C => C.Descricao == alunoDTO.Curso);
            if (Curso == null) return BadRequest("Curso não encontrado");

            aluno.Nome = alunoDTO.Nome;
            aluno.CursoId = Curso.ID;

            _context.Alunos.Update(aluno);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var aluno = await _context.Alunos.FindAsync(id);
            if (aluno == null) return BadRequest("Aluno não encontrado");

            _context.Alunos.Remove(aluno);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpGet("buscarpornome/{nome}")]
        public async Task<ActionResult<AlunoReadDTO>> BuscarPorNome(string nome)
        {
            var aluno = await _context.Alunos
                .Include(a => a.Curso)
                .FirstOrDefaultAsync(a => a.Nome == nome);

            if (aluno == null)
                return NotFound("Aluno não encontrado");

            var alunoDTO = new AlunoReadDTO
            {
                ID = aluno.ID,
                Nome = aluno.Nome,
                Curso = aluno.Curso.Descricao
            };

            return Ok(alunoDTO);
        }

    }
}