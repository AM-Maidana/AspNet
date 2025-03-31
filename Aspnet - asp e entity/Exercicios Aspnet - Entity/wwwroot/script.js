// vou criar uma variavel que vai receber o endereço da Apliação ASP.Net
const API = "http://localhost:5000/Usuario";

// A gente vai atribuir os valores dos campos do formulário para um objeto
// document é um objeto que representa a página HTML
// getElementById é um método que retorna um elemento HTML com base no ID
document.getElementById("usuarioform").addEventListener("submit", salvarUsuario);
carregarUsuarios(); // Carregar os usuários que é uma função que vamos criar


function carregarUsuarios() {
    // fetch é uma função que faz uma requisição HTTP

    fetch(API)
        .then(res => res.json()) // res.json() é uma função que converte o conteúdo da resposta para JSON
        .then(data => {
            const tbody = document.querySelector("#tabelaUsuarios tbody");
            tbody.innerHTML = ""; // innerHTML é uma propriedade que define ou retorna o conteúdo HTML de um elemento
            data.forEach(usuario => {
                tbody.innerHTML += `
                    <tr>
                        <td>${usuario.id}</td>
                        <td>${usuario.nome}</td>
                        <td>${usuario.password}</td>
                        <td>${usuario.ramal}</td>
                        <td>${usuario.especialidade}</td>
                        <td>
                            <button class="edit" onclick="editarUsuario(${usuario.id})">Editar</button>
                            <button class="delete" onclick='deletarUsuario(${usuario.id})'>Deletar</button>
                        </td>
                    </tr>
                `;
            }
            )
        })
}

function salvarUsuario(event) {
    event.preventDefault(); // Previne o comportamento padrão do formulário (não envia e recarrega a página)
    
    const id = document.getElementById("id").value; // Obtém o valor do ID
    const usuario = {
        id: parseInt(id || 0), // Se o ID estiver vazio, define 0
        nome: document.getElementById("nome").value,
        password: document.getElementById("password").value,
        ramal: document.getElementById("ramal").value,
        especialidade: document.getElementById("especialidade").value
    };
    
    // Verifica se o ID já existe
    fetch(`${API}/${usuario.id}`)
        .then(res => {
            if (res.status === 404) { // Se o usuário não for encontrado, retorna 404
                console.log("Usuário não encontrado. Criando novo...");
                return fetch(API, { // Realiza um POST para criar o usuário
                    method: "POST",
                    headers: {
                        "Content-Type": "application/json"
                    },
                    body: JSON.stringify(usuario)
                });
            } else if (res.ok) { // Se o status for 200, o usuário existe
                console.log("Usuário encontrado. Atualizando...");
                return fetch(`${API}/${usuario.id}`, { // Realiza um PUT para atualizar
                    method: "PUT",
                    headers: {
                        "Content-Type": "application/json"
                    },
                    body: JSON.stringify(usuario)
                });
            } else {
                throw new Error("Erro ao verificar o usuário.");
            }
        })
        .then(res => res.json()) // Converte a resposta para JSON
        .then(() => {
            document.getElementById("usuarioform").reset(); // Reseta o formulário
            carregarUsuarios(); // Atualiza a lista de usuários
        })
        .catch(err => console.error("Erro:", err));
}


function editarUsuario(id){
    fetch(`${API}/${id}`) // faz uma requisição GET para pegar o usuário pelo id
        .then(res => res.json()) // converte a resposta para JSON
        .then(usuario => { // aqui ele vai preencher os campos do formulário com os dados do usuário
            document.getElementById("id").value = usuario.id; // preenche o campo id
            document.getElementById("nome").value = usuario.nome; // preenche o campo nome
            document.getElementById("password").value = usuario.password; // preenche o campo password
            document.getElementById("ramal").value = usuario.ramal; // preenche o campo ramal
            document.getElementById("especialidade").value = usuario.especialidade; // preenche o campo especialidade
        });
}

function deletarUsuario(id) {
    
    // Aqui ele vai fazer a requisição DELETE para deletar o usuário
    fetch(`${API}/${id}`, { method: "DELETE" }) // faz uma requisição DELETE para a API + id
        .then(() => carregarUsuarios()); // chama a função para carregar a lista de usuários novamente
}