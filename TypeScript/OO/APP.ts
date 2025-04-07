import { Pessoa } from "./Pessoa.ts";
import { ContaCorrente, Poupanca } from "./Conta.ts";


function main() {
    try{
        const cliente1 = new Pessoa("João", 30);
        const cliente2 = new Pessoa("Maria", 25);
        
        const contaCorrente = new ContaCorrente(cliente1, 1000, 500);
        const poupanca = new Poupanca(cliente2, 2000, 100);

        contaCorrente.depositar(500);
        contaCorrente.sacar(200);
        contaCorrente.exibirDados();

        poupanca.aplicarRendimento();
        poupanca.sacar(100);

        console.log(poupanca.exibirDados());
        console.log(contaCorrente.exibirDados());
        

        
    }
    catch (error: any) {
        console.error("Erro", error.message);
    }

}
main(); // Executa a função principal