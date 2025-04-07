export class Pessoa {
    //encapsulamento
    private nome: string;
    private idade: number;

    //construtor
    constructor(nome: string, idade: number) {
        this.nome = nome;
        this.idade = idade;
    }
    
    //getters e setters
    public getnome(): string {
        return this.nome;
    }
    public setnome(nome: string): void {
        if(nome.length < 3){
            throw new Error("nome deve ter mais de 3 caracteres.");
        }
        this.nome = nome;
    }
    public getidade(): number {
        return this.idade;
    }
    public setidade(idade: number): void {
        if(idade < 0 ){
            throw new Error("idade deve ser maior que 0.");
        }
        this.idade = idade;
    }

    // Método de informações de Pessoa
    public exibirDados(): string {
        return `Nome: ${this.nome}, Idade: ${this.idade}`;
    }
}