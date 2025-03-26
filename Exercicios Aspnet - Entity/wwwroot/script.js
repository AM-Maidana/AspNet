// Vou criar uma variavel que vai receber o endereço da aplicação ASP.NET
const API = "http://localhost:5000/Usuario";

// Função que vai fazer a requisição para API
document.getElementById("usuarioForm").addEventListener("submit", salvarUsuario);
carregarUsuarios();// Carregar os usuarios que é uma função que vamos criar

function carregarUsuarios()
{
    fetch(API)
    .then(res => res.json()) //res.json() é uma função que converte o conteúdo da resposta para Json
    .then(data =>{
        const tbody = document.querySelector("#tabelaUsuarios tbody");
        tbody.innerHTML = "";
        //innerHTML é uma propriedade que define ou retorna o conteúdo HTML de um elemento
        data.forEach(usuario => {
            tbody.innerHTML += `
            <tr>
                <td>${usuario.id}</td>
                <td>${usuario.nome}</td>
                <td>${usuario.senha}</td>
                <td>${usuario.ramal}</td>
                <td>${usuario.especialidade}</td>
                <td>
                    <button class="edit" onclick="editarUsuario(${usuario.id})"></button>
                    <button class="delete" onclick="deletarUsuario(${usuario.id})">Deletar</button>
                </td>
                </tr>
            `;
        }
    )
    })
}