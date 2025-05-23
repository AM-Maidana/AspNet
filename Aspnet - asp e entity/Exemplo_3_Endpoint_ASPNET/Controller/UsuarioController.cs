using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Exemplo_3_Endpoint_ASPNET_Banco.Models;
using Exemplo_3_Endpoint_ASPNET_Banco.database;

using Microsoft.EntityFrameworkCore;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Exemplo_3_Endpoint_ASPNET_Banco.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly AppDbContext _context; //Readonly é uma variável que só pode ser inicializada no construtor,
        /*o AppDbContext é a classe que representa o banco de dados*/
        public UsuarioController(AppDbContext context) /*Construtor que recebe p 
        AppDbContext que é a classe que representa o banco de dados*/
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IEnumerable<Usuario>> Get() //retorna uma lista de usuários
        {
            /*await é uma palavra chave que só pode swe usada em metódos que são marcados com async*/
            return await _context.Usuarios.ToListAsync(); // Retorna todos os usuários do banco

        }
        [HttpPost]
        public async Task<ActionResult<Usuario>> Post([FromBody] Usuario usuario)
        {
            _context.Usuarios.Add(usuario); //Adiciona o usuario no banco de dados
            await _context.SaveChangesAsync(); // Salva as alterações do banco

            return usuario; // Retorna o usuári
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Usuario>> Put (int id, [FromBody] Usuario usuario)
        {
            var existente = await _context.Usuarios.FindAsync(id);
            if (existente == null) return NotFound();

            existente.Nome = usuario.Nome;
            existente.Email = usuario.Email;

            await _context.SaveChangesAsync();
            
            return existente;
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existente = await _context.Usuarios.FindAsync(id);
            if (existente == null) return NotFound();

            _context.Usuarios.Remove(existente);
            await _context.SaveChangesAsync();
            return NoContent(); // retorna um status 204
        }
    }
}