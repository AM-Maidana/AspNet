using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Exercicios_ASPNET_Banco.Models;
using Exercicios_ASPNET_Banco.database;

using Microsoft.EntityFrameworkCore;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Exercicios_ASPNET_Banco.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class MaquinaController : ControllerBase
    {
        private readonly AppDbContext _context; //Readonly é uma variável que só pode ser inicializada no construtor,
        /*o AppDbContext é a classe que representa o banco de dados*/
        public MaquinaController(AppDbContext context) /*Construtor que recebe p 
        AppDbContext que é a classe que representa o banco de dados*/
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IEnumerable<Maquina>> Get() //retorna uma lista de usuários
        {
            /*await é uma palavra chave que só pode swe usada em metódos que são marcados com async*/
            return await _context.Maquinas.ToListAsync(); // Retorna todos os usuários do banco

        }
        [HttpPost]
        public async Task<ActionResult<Maquina>> Post([FromBody] Maquina maquina)
        {
            _context.Maquinas.Add(maquina); //Adiciona o usuario no banco de dados
            await _context.SaveChangesAsync(); // Salva as alterações do banco

            return maquina; // Retorna o usuári
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Maquina>> Put (int id, [FromBody] Maquina maquina)
        {
            var existente = await _context.Maquinas.FindAsync(id);
            if (existente == null) return NotFound();

            existente.tipo = maquina.tipo;
            existente.velocidade = maquina.velocidade;
            existente.harddisk = maquina.harddisk;
            existente.placarede = maquina.placarede;
            existente.memoriaram = maquina.memoriaram;
            existente.usuario_id = maquina.usuario_id;

            await _context.SaveChangesAsync();
            
            return existente;
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existente = await _context.Maquinas.FindAsync(id);
            if (existente == null) return NotFound();

            _context.Maquinas.Remove(existente);
            await _context.SaveChangesAsync();
            return NoContent(); // retorna um status 204
        }
    }
}