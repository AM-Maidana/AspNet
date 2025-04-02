import { Animal } from './Animal.js';

export class Leao extends Animal {
    static veroz = true;

    constructor(nome, raca, peso, idade, sexo){
        super(nome, raca, peso, idade);
        this.sexo = sexo;
    }

    procriar(){
        console.log("O Liaum está procriando");
    }
}