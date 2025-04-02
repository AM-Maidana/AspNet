import { Animal } from './Animal.js';

export class Cobra extends Animal {
    static venenosa = true; // static é um atributo qe classe que nçai pode ser alterado na classe filha

    constructor(nome, raca, peso, idade, cor){
        super(nome, raca, peso, idade);
        this.cor = cor;
    }

    // Sobreescreve o metodo procirar na classe pai
    procriar(){
        console.log("A cobra botou ovos");
    }
}