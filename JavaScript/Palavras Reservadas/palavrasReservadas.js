let pessoa = {
    nome: "Amanda"
}

let pessoa2 = {

}

//Palavras reservadas no JS
console.log(Object.getOwnPropertyDescriptor(pessoa)); // Mostra os atributos e métodos do objeto

// Assign, ele faz uma cópia do objeto
Object.assign(pessoa2, pessoa);

// Agora desestruturar um objeto, criando variáveis
let config = {
    ip: '127.0.0.1',
    port: '8080',
    block: true,
}
let { ip, port, block } = config; //desestrutura o objeto
console.log(ip, port, block); // imprime os valores das variáveis

// Desestruturar um array
let lista = ['Lucas', 'Maria', 'Joao'];
let [nome1, nome2, nome3] = lista; //desestrutura o array

console.log(nome1, nome2, nome3);

//Desestruturar um arrau com o rest operator
let lista2 = ['lucas', 'maria', 'joao', 'jose'];
let [nome4, ...resto] = lista2;

console.log(nome4);

console.log(resto);

