//Criar um objeto em JavaScript é muito simples, basta criar uma váriavel e atribuir ela a um objeto com chaves e valores
let carro ={
    marca: "Renault",
    modelo: "kwid",
    ano: 2021,
    
    ligar: function(){
        console.log("vrum vrum");
    }
}

console.table(carro); //Exibe em forma de tabelinha


console.log(carro.toString()); //o tipo do objeto
 ///// exemplo de como chamar a função
 console.log(carro.ligar()); //- imprime mas da undefined
 
 carro.ligar(); // n aparece undefined

 //Modificar os valores
 carro.marca = "chevrolet";
 carro.modelo = "onix";
 console.log(carro);

 //Deletando propriedades do objeyo
 delete carro.ano;
console.log(carro);

//Alguns operadores do objeyo
console.log('marca' in carro);
console.log('ano' in carro);