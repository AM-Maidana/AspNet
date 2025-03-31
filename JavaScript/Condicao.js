// Todos os tipos de Condição
// Condição Simples
let idade = 18;
if (idade >= 18) {
    console.log("Maior de idade");
}
// Condição Composta
if (idade >= 18) {
    console.log("Maior de idade");
} else {
    console.log("Menor de idade");
}
// Condição composta com else if
if (idade >= 18) {
    console.log("Maior de idade");
} else if (idade >= 12) {
    console.log("Adolescente");
}
else {
    console.log("Criança");
}

// Condição Ternario
let podeVotar = (idade >= 18) ? "Pode votar" : "Não pode votar";
console.log(podeVotar);

// tenario com mais de 2 condições
let podeVotar2 = (idade >= 18) ? "Pode votar" : (idade >= 12) ? "Adolescente" : "Criança";
console.log(podeVotar2);

// Ternario com operador lógico
let podeVotar3 = (idade >= 18 && idade <= 70) ? "Pode votar" : "Não pode votar";
console.log(podeVotar3);

// Ternario com || operador lógico
let podeVotar4 = (idade < 18 || idade > 70) ? "Não pode votar" : "Pode votar";
console.log(podeVotar4);

// Condição !=
let podeVotar5 = (idade != 18) ? "Não pode votar" : "Pode votar";
console.log(podeVotar5);


// Condição Switch
let dia = 5;
switch (dia) {
    case 1:
        console.log("Domingo");
        break;
    case 2:
        console.log("Segunda-feira");
        break;
    case 3:
        console.log("Terça-feira");
        break;
    case 4:
        console.log("Quarta-feira");
        break;
    case 5:
        console.log("Quinta-feira");
        break;
    case 6:
        console.log("Sexta-feira");
        break;
    case 7:
        console.log("Sábado");
        break;
    default:
        console.log("Dia inválido");
}