// Criar um objeto parecido com função construtora, mas é um objeto literal
// Que no final é um objeto, mas pode ter parametros e funções

// Objeto Literal Jogador
function Jogador(nome, idade) {
    // nome = nome;
    // idade = idade;
    this.nome = nome;  // outra forma de atribuir valor 
    this.idade = idade;
    this.chutar = function () {
        console.log(this.nome + " chutou a bola");
    }
}

function Time (nome, qtd) {
    this.nome = nome;
    this.qtd = qtd;
    this.jogadores = [];
    this.addJogador = function (jogador) {
        this.jogadores.push(jogador);
    }
}

function compare (obj1, obj2) {
    if (obj1 instanceof obj2) {
        console.log("São iguais");
    }
    else {
        console.log("São diferentes");
    }
}

// Criando um objeto jogador
let jogador1 = new Jogador("Caça rato", 30);
let jogador2 = new Jogador("Yuri Alberto", 25);

let time1 = new Time("São Paulo", 11);

console.log(jogador1 instanceof Jogador);