import { Pessoa } from "./Pessoa.ts";

export class Conta {
    protected titular: Pessoa;
    protected saldo: number;

    // Construtor
    constructor(titular: Pessoa, saldo: number) {
        this.titular = titular;
        this.saldo = saldo;
    }

    // metodo para depositar
    public depositar(valor: number): void {
        if (valor <= 0) {
            throw new Error("Valor de depósito deve ser maior que zero.");
        }
        this.saldo += valor;
    }

    // Saque
    public sacar(valor: number): void {
        if (valor <= 0) {
            throw new Error("Valor de saque deve ser maior que zero.");
        }
        if (valor > this.saldo) {
            throw new Error("Saldo insuficiente.");
        }
        this.saldo -= valor;
    }
    // polimorfismo p/ ver os dados
    public exibirDados(): string {
        return `Titular: ${this.titular.exibirDados()}, Saldo: ${this.saldo}`;
    }
}
//------------------------------
// classe Poupança
export class Poupanca extends Conta {
    private taxaRendimento: number;

    constructor(titular: Pessoa, saldo: number, taxaRendimento: number) {
        super(titular, saldo);//chama o construtor da classe pai
        this.taxaRendimento = taxaRendimento;
    }

    //Aplica rendimento
    public aplicarRendimento(): void {
        this.saldo += this.saldo * (this.taxaRendimento / 100);
    }

    //Polimorfismo de subeescrver o método
    public override exibirDados(): string {
        //chama o metodo da classe pai
        return `Titular: ${this.titular.getnome()}, Saldo: ${this.saldo}, Rendimento: ${this.taxaRendimento}%`;
    }
}

//------------------------------
// classe CC
export class ContaCorrente extends Conta {
    private limiteChequeEspecial: number;

    // Construtor
    constructor(titular: Pessoa, saldo: number, limiteChequeEspecial: number) {
        super(titular, saldo);//chama o construtor da classe pai
        this.limiteChequeEspecial = limiteChequeEspecial;
    }
    //Saque com cheque especial - tem que ter limite
    public override sacar(valor: number): void {
        if (valor > this.saldo + this.limiteChequeEspecial) {
            throw new Error("Saldo insuficiente e limite de cheque especial excedido.");
        }
        this.saldo -= valor;
    }

    public override exibirDados(): string {
        return `Titular: ${this.titular.getnome()}, Saldo: ${this.saldo}, Limite Cheque Especial: ${this.limiteChequeEspecial}`;        
    }
}