//Instalando o TypeScript
//npm install -g typescript
//tsc --version

//Operadores no typescript
// -- Aritméticos 
let a: number = 10; //são os tupos primitivos do typescript é igual ao Javascript
let b: number = 20;
let total: number = a + b; //soma
let subtracao:  number = a - b; //subtração
let multiplicacao: number = a * b; //multiplicação
let divisao: number = a / b; //divisão
let resto: number = a % b; //resto da divisão

console.log("Soma: " + total);
console.log("Subtração: " + subtracao);
console.log("Multiplicação: " + multiplicacao);
console.log("Divisão: " + divisao);
console.log("Resto: " + resto);

// Comando para poder executar o codigo em typescript, sem precisar criar o arquivo .js
// é usando o ts-node
//npm install -g ts-node
//-----------------------------------
// -- Operadores com texto
let nome: string = "Lucas"; //string
let sobrenome: string = "Pereira"; //string
let textoConcatenado: string = nome + " " + sobrenome; //concatenação de strings
console.log("Nome completo: " + textoConcatenado); //imprimindo o nome completo
let textoRepetido: string = nome.repeat(3); //repetição de strings
console.log("Nome repetido: " + textoRepetido); //imprimindo o nome repetido


//Diferenã de tsc e ts-node
/*TSC - compila o arquivo TypeScript para JavaScript
TS-NODE - executa o arquivo Type diretamente sem precisar compilar pars JS */

//------------------------------------
// -- Operadores de comparação
let comparacao1: boolean = a == b; //igualdade
let comparacao2: boolean = a != b; //desigualdade
let comparacao3: boolean = a === b; //igualdade estrita
let comparacao4: boolean = a !== b; //desigualdade estrita
console.log("Igualdade: " + comparacao1); //imprimindo a igualdade
console.log("Desigualdade: " + comparacao2); //imprimindo a desigualdade    
console.log("Igualdade estrita: " + comparacao3); //imprimindo a igualdade estrita
console.log("Desigualdade estrita: " + comparacao4); //imprimindo a desigualdade estrita

//------------------------------------
// -- Operadores de comparação com logicos
let compracao5: boolean = a > 0 && b > 0; //maior que
let comparacao6: boolean = a < 0 || b < 0; //menor que
let comparacao7: boolean = !(a == b); //negação
console.log("Maior que: " + compracao5); //imprimindo o maior que
console.log("Menor que: " + comparacao6); //imprimindo o menor que
console.log("Negação: " + comparacao7); //imprimindo a negação

//------------------------------------
// -- Operadores ternarios
let resultado: string = (a > b) ? "A é maior que B" : "B é maior que A"; //operador ternário
console.log(resultado); //imprimindo o resultado do operador ternário

//------------------------------------
// -- Operadores de atribuição
let valor: number = 10; //atribuição simples
valor += 5; //atribuição de soma
valor -= 5; //atribuição de subtração
valor *= 5; //atribuição de multiplicação
valor /= 5; //atribuição de divisão
valor %= 5; //atribuição de resto da divisão
console.log("Valor: " + valor); //imprimindo o valor

//------------------------------------
let contador: number = 0; //contador
contador++; //incremento
contador--; //decremento
console.log("Contador: " + contador); //imprimindo o contador

//------------------------------------
// -- Operador de Nullish coalescing
let valorNulo: number | null = null; //valor nulo
let valorDefault: number = valorNulo ?? 10; //operador de nullish coalescing
console.log(`Valor Nulo: ${valorNulo}`); //imprimindo o valor nulo
console.log(`Valor Default: ${valorDefault}`); //imprimindo o valor default

//------------------------------------
// --Operadores de spread
let numeros: number[] = [1, 2, 3]; //array de numeros
let novoArray: number[] = [...numeros, 4, 5]; //operador de spread
console.log("Novo Array: " + novoArray); //imprimindo o novo array

//------------------------------------
// -- Operadores de destructuring
let pessoa: { nome: string; idade: number } = { nome: "Lucas", idade: 25 }; //objeto pessoa
let { nome: nomePessoa, idade: idadePessoa } = pessoa; //destructuring
console.log(`Nome:  ${nomePessoa} + Idade: ${idadePessoa}`); //imprimindo o nome da pessoa

//----------------------------------------
// Vamos criar um objeto e como ele pode ser chamado
let objeto: { nome: string; idade: number } = { nome: "Lucas", idade: 25 }; //objeto pessoa
let resultados: {[key: string]: number | string | boolean} = {
    soma: total,
    subtracao: subtracao,
    multiplicacao: multiplicacao,  
    divisao: divisao,
    resto: resto,
}

let resultado2: {[nome: string]: any} = {
    nome: "Amanda",
    idade: "21",
    ativo: true,
    endereco: {
        rua: "Rua 1",
        numero: 123,
    },
}

// chamandi
console.log(resultados["soma"]);