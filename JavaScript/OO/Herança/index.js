import { Animal  } from "./Animal.js";
import { Cobra } from './Cobra.js';
import { Leao } from './Leao.js';

const animal = new Animal("Animal", "raca", 10, 5);
const cobra = new Cobra("Cobra", "raca", 1,1, "coral");
const leao = new Leao("Liaum", "simba", 3, 5, "macho");

console.table(cobra);
console.table(leao);