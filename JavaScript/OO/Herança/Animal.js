export class Animal {
    constructor(nome, raca, peso, idade){
        this.nome = nome;
        this.raca = raca;
        this.peso = peso;
        this.idade = idade;
    }

    pocriar(){
        console.log("Animal está procriando");
    }


    getNome() {
        return this.nome;
    }
    setNome(nome) {
        this.nome = nome;
    }
    getRaca(){
        return this.raca;
    }
    setRaca(raca){
        this.raca = raca;
    }
    getPeso(){
        return this.peso;
    }
    setPeso(peso){
        this.peso = peso;
    }
    getIdade() {
        return this.idade;
    }
    setIdade(idade) {
        this.idade = idade;
    }
}