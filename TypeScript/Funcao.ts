//Criar função type
type funcao = (a: number, b: number) => number; //definindo o tipo da função{
    
function soma(a: number, b: number): number {
    return a + b; //soma
}

//---------
// Arrow function
const somaArrow: funcao = (a, b) => a + b; //definindo a função como arrow function

//---------
// Função anônima
const somaAnonima: funcao = function (a, b){
    return a + b; 
}

//---------
// Funcao com retorno implícit
const somaRetornoImplicito: funcao = (a, b) => a + b; //definindo a função com retorno implícito

const somaComParametrosOpcionais = (a: number, b?: number) => a + (b ?? 0);

// Vamps executar esse arquivo usando a ferramenta deno, que é uma ferramenta de execução de código TS
console.log(`aaaaaa`);