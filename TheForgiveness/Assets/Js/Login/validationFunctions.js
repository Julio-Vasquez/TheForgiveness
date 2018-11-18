const inp = document.getElementsByClassName('wrap-input');

function addElement(dad) {
    let newElement = document.createElement('label');
    newElement.setAttribute('name', 'lbval');
    dad.appendChild(newElement);
}

window.onload = () => {
    document.getElementById('btn').addEventListener('click', () => {
        for (let i = 0; i < inp.length; i++) {
            if (validate(inp[i].firstElementChild)) {
                showClass(inp[i]);
            }
        }
    });
    for (let i = 0; i < inp.length; i++) {
        addElement(inp[i].parentNode);
        let dad = inp[i];
        inp[i].firstElementChild.addEventListener('focus', () => {
            hideClass(dad);
        });
    }
}

function showClass(dad) {
    dad.parentNode.lastElementChild.classList.add('alert-validate');
    dad.firstElementChild.classList.add('bi-red');
    dad.parentNode.firstElementChild.classList.add('lb-red');
    dad.lastElementChild.classList.add('lb-red');

}

function hideClass(dad) {
    dad.parentNode.lastElementChild.textContent = '';
    dad.firstElementChild.classList.remove('bi-red');
    dad.parentNode.firstElementChild.classList.remove('lb-red');
    dad.lastElementChild.classList.remove('lb-red');
}

function validate(input) {
    return (input.value != undefined) ? (input.value.trim() == '') ? true : false : false;
}