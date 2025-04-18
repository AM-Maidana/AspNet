using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using System.Linq;
using System.Runtime.Versioning;
using System.Threading.Tasks;
using Exemplo_2_Aspnet;


// Ora poder fazer o protocolo HTTP, precisamos de um controller da biblioteca do ASP.NET, que é o MVC, no qual lá tem os controllers
using Microsoft.AspNetCore.Mvc;

namespace Aula_2_EndPoint.Controller
{
    // Vamos Adicionar um Anotation para dizer que essa classe é um controller para referenciar os endipoints e metodos HTTP
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        // Vou instanciar os valores em uma lista na variavel usuarios
        private static List<Usuario> usuarios = new List<Usuario>()
        {
            new Usuario {Id = 1, Nome = "João", Email = "joao@gmail.com"},
            new Usuario {Id = 2, Nome = "Maria", Email = "maria@gmail.com"},
            new Usuario {Id = 3, Nome = "José", Email = "jose@gmail.com"}
        };

        // Vamo chamar o anotation para definir a rota para acessar esse metodo de requisição HTTP
        [HttpGet]
        public IEnumerable<Usuario> Get() // IEnumerable é uma interface que representa uma coleção de objetos que podem ser iterados
        {
            return usuarios; // Vai retornar a lista de usuarios
        }

        // Vamos chamar o anotation para definir a rota para acessar esse metoo de requiseção HTTP de adicionar um usuario
        [HttpPost]
        public Usuario Post([FromBody] Usuario usuario) // [FromBody]é um atributo que indica que um parâmetro de ação deve ser ligado ao corpo da solicitação HTTP. O atributo [FromBody] informa ao MVC para ler o valor do corpo da solicitação HTTP e ligá-lo ao parâmetro do método
        {
            usuarios.Add(usuario); // Vai adicionar o usuario na lista de usuarios
            return usuario; // vai retornar o usuario
        }

        [HttpPut]
        public void Put(int id, [FromBody] Usuario usuario) // [HttpPut("{id})] é um atributo que indica que um parâmetro de ação deve ser ligado ao corpo da solicitação HTTP. O atributo [Http("{id})] informa ao MVC para ler o valor do corpo da solicitação HTTP e ligá-lo ao parâmetro do método
        {
            var usuarioExistente = usuarios.Where(x => x.Id == id).FirstOrDefault(); // Vai pegar o usuario existente
            // se quiser adicionar o where, posso ficar somente com o FirstOrDefault() para pegar o primeiro elemento da lista
            // var usuarioExistente = usuarios.Where(x => x.Id == id).FirstOrDefault();
            if(usuarioExistente != null) // se o usuario existente for diferente de nulo
            {
                usuarioExistente.Nome = usuario.Nome;
                usuarioExistente.Email = usuario.Email;

            }
        }

        [HttpDelete("{id}")] //httpDelete {id} é um atributo que indica que um parametro de ação deve ser ligado ao copo da solicitação
        //Http. O atributo httpDelete 
        public void Delete(int id) 
        {
            var usuarioExistente = usuarios.Where(x => x.Id == id).FirstOrDefault();

            if(usuarioExistente != null)
            {
                usuarios.Remove(usuarioExistente);
            }
        }
    }
}