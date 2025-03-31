
const API = "http://localhost:5000/Maquina";

document.getElementById("maquinaForm").addEventListener("submit", salvarMaquina);
carregarMaquinas(); 


function carregarMaquinas() {
    fetch(API)
        .then(res => res.json()) 
        .then(data => {
            const tbody = document.querySelector("#tabelaMaquinas tbody");
            tbody.innerHTML = ""; 
            data.forEach(maquina => {
                tbody.innerHTML += `
                    <tr>
                        <td>${maquina.id}</td>
                        <td>${maquina.tipo}</td>
                        <td>${maquina.velocidade}</td>
                        <td>${maquina.hardDisk}</td>
                        <td>${maquina.placaRede}</td>
                        <td>${maquina.memoriaRam}</td>
                        <td>${maquina.fkUsuario}</td>
                        <td>
                            <button class="edit" onclick="editarMaquina(${maquina.id})">Editar</button>
                            <button class="delete" onclick='deletarMaquina(${maquina.id})'>Deletar</button>
                        </td>
                    </tr>
                `;
            }
            )
        })
}

function salvarMaquina(event) {
    event.preventDefault(); 
    
    const id = document.getElementById("id").value; 
    const maquina = {
        id: parseInt(id || 0), 
        tipo: document.getElementById("tipo").value,
        velocidade: document.getElementById("velocidade").value,
        hardDisk: document.getElementById("HardDisk").value,
        placaRede: document.getElementById("placaRede").value,
        memoriaRam: document.getElementById("memoriaRam").value,
        fkUsuario: document.getElementById("fkUsuario").value
    };
    

    fetch(`${API}/${maquina.id}`)
        .then(res => {
            if (res.status === 404) { 
                console.log("Maquina não encontrada. Criando uma nova...");
                return fetch(API, { 
                    method: "POST",
                    headers: {
                        "Content-Type": "application/json"
                    },
                    body: JSON.stringify(maquina)
                });
            } else if (res.ok) {
                console.log("Maquina encontrada. Atualizando...");
                return fetch(`${API}/${maquina.id}`, { 
                    method: "PUT",
                    headers: {
                        "Content-Type": "application/json"
                    },
                    body: JSON.stringify(maquina)
                });
            } else {
                throw new Error("Erro ao verificar a máquina.");
            }
        })
        .then(res => res.json()) 
        .then(() => {
            console.info;
            document.getElementById("maquinaForm").reset(); 
            carregarMaquinas(); 
        })
        .catch(err => console.error("Erro:", err));
}


function editarMaquina(id){
    fetch(`${API}/${id}`) 
        .then(res => res.json()) 
        .then(maquina => { 
            document.getElementById("id").value = maquina.id; 
            document.getElementById("tipo").value = maquina.tipo; 
            document.getElementById("velocidade").value = maquina.velocidade; 
            document.getElementById("HardDisk").value = maquina.hardDisk;
            document.getElementById("placaRede").value = maquina.placaRede; 
            document.getElementById("memoriaRam").value = maquina.memoriaRam;
            document.getElementById("fkUsuario").value = maquina.fkUsuario;
        });
}

function deletarMaquina(id) {
    fetch(`${API}/${id}`, { method: "DELETE" }) 
        .then(() => carregarMaquinas()); 
}