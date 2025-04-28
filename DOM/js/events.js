let count = 1;

function addItem () {
    const item = document.createElement('li'); //cria o elemento li
    const list = document.querySelector('ol'); // pega o elemento ol

    item.innerText = `Item ${count}`; // adiciona o texto ao elemento li
    list.appendChild(item); // adiciona o elemento li ao elemento ol
}

function removeItem () {
    const list = document.querySelector('ol'); // pega o elemento ol
    const item = list.querySelector('li:first-child'); // pega todos os elementos li dentro do elemento ol

    list.removeChild(item);
}

const buttonAdd = document.getElementById('new_item'); // pega o elemento button
const buttonRemove = document.getElementById('remove_item'); // pega o elemento button

buttonAdd.addEventListener('click', addItem); // adiciona o evento de click ao botão
buttonRemove.addEventListener('click', removeItem); // adiciona o evento de click ao botão