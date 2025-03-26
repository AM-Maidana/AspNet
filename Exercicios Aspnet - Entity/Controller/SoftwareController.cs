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
    public class SoftwareController : ControllerBase
    {
        private readonly AppDbContext _context; //Readonly é uma variável que só pode ser inicializada no construtor,
        /*o AppDbContext é a classe que representa o banco de dados*/
        public SoftwareController(AppDbContext context) /*Construtor que recebe p 
        AppDbContext que é a classe que representa o banco de dados*/
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IEnumerable<Software>> Get() //retorna uma lista de usuários
        {
            /*await é uma palavra chave que só pode swe usada em metódos que são marcados com async*/
            return await _context.Softwares.ToListAsync(); // Retorna todos os usuários do banco

        }
        [HttpPost]
        public async Task<ActionResult<Software>> Post([FromBody] Software software)
        {
            _context.Softwares.Add(software); //Adiciona o usuario no banco de dados
            await _context.SaveChangesAsync(); // Salva as alterações do banco

            return software; // Retorna o usuári
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Software>> Put (int id, [FromBody] Software software)
        {
            var existente = await _context.Softwares.FindAsync(id);
            if (existente == null) return NotFound();

            existente.produto = software.produto;
            existente.hardDisk = software.hardDisk;
            existente.memoria_Ram = software.memoria_Ram;
            existente.maquina_id = software.maquina_id;



            await _context.SaveChangesAsync();
            
            return existente;
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existente = await _context.Softwares.FindAsync(id);
            if (existente == null) return NotFound();

            _context.Softwares.Remove(existente);
            await _context.SaveChangesAsync();
            return NoContent(); // retorna um status 204
        }
    }
}