const API = "http://localhost:5000/Software";

document.getElementById("softwareForm").addEventListener("submit", salvarSoftware);
carregarSoftwares(); 

function carregarSoftwares() {
    fetch(API)
        .then(res => res.json()) 
        .then(data => {
            const tbody = document.querySelector("#tabelaSoftware tbody");
            tbody.innerHTML = ""; 
            data.forEach(software => {
                tbody.innerHTML += `
                    <tr>
                        <td>${software.id}</td>
                        <td>${software.produto}</td>
                        <td>${software.hardDisk}</td>
                        <td>${software.memoriaRam}</td>
                        <td>${software.fkMaquina}</td>
                        <td>
                            <button class="edit" onclick="editarSoftware(${software.id})">Editar</button>
                            <button class="delete" onclick='deletarSoftware(${software.id})'>Deletar</button>
                        </td>
                    </tr>
                `;
            });
        });
}

function salvarSoftware(event) {
    event.preventDefault(); 

    const id = document.getElementById("id").value;
    const software = {
        id: parseInt(id || 0), 
        produto: document.getElementById("produto").value,
        Harddisk: document.getElementById("Harddisk").value,
        memoriaRam: document.getElementById("memoriaRam").value,
        fkMaquina: document.getElementById("fkMaquina").value
    };

    fetch(`${API}/${software.id}`)
        .then(res => {
            if (res.status === 404) { 
                console.log("Software não encontrado. Criando um novo...");
                return fetch(API, { 
                    method: "POST",
                    headers: {
                        "Content-Type": "application/json"
                    },
                    body: JSON.stringify(software)
                });
            } else if (res.ok) {
                console.log("Software encontrado. Atualizando...");
                return fetch(`${API}/${software.id}`, { 
                    method: "PUT",
                    headers: {
                        "Content-Type": "application/json"
                    },
                    body: JSON.stringify(software)
                });
            } else {
                throw new Error("Erro ao verificar o software.");
            }
        })
        .then(res => res.json()) 
        .then(() => {
            document.getElementById("softwareForm").reset(); 
            carregarSoftwares(); 
        })
        .catch(err => console.error("Erro:", err));
}

function editarSoftware(id) {
    fetch(`${API}/${id}`) 
        .then(res => res.json()) 
        .then(software => { 
            document.getElementById("id").value = software.id; 
            document.getElementById("produto").value = software.produto; 
            document.getElementById("hardDisk").value = software.hardDisk; 
            document.getElementById("memoriaRam").value = software.memoriaRam;
            document.getElementById("fkMaquina").value = software.fkMaquina;
        });
}

function deletarSoftware(id) {
    fetch(`${API}/${id}`, { method: "DELETE" }) 
        .then(() => carregarSoftwares()); 
}
