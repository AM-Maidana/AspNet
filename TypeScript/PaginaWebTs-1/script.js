function saudarTratado() {
    // tentar obter o elemento com o id "saudacao"
    var input = document.getElementById("nome");
    // verificar se o elemento existe e é um input
    if (input && input instanceof HTMLInputElement) {
        // obter o valor do input
        var nome = input.value.trim(); //remover espaços em branco no início e no fim
        // Verifica se o elemento existe
        if (nome === "") {
            //Definiir o conteúdo do elemento
            alert("Por favor, digite seu nome.");
        }
        else {
            alert("Ol\u00E1 ".concat(nome, ", tudo bem?"));
        }
    }
    else {
        console.error("Elemento com id 'saudacao' não encontrado");
    }
}
