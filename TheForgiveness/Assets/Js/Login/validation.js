const input = document.getElementsByClassName('input');

input[0].onkeyup = function() { //solo letras sin espacio Nombre
    let patterns = /[^a-zA-ZáéíóúAÉÍÓÚÑñ]*$/;
    let caretPos = this.selectionStart;
    this.value = input[0].value.replace(patterns, '');
    this.setSelectionRange(caretPos, caretPos);
}

input[1].onkeyup = function() { // password
    let patterns = /[^a-zA-ZáéíóúAÉÍÓÚÑñ0-9]*$/;
    let caretPos = this.selectionStart;
    this.value = input[1].value.replace(patterns, '');
    this.setSelectionRange(caretPos, caretPos);
}

function setError(inp, sms) {
    inp.parentNode.parentNode.lastElementChild.textContent = sms;
    showClass(inp.parentNode);
}

function validation(inp, minLength, maxLength) {
    if (validate(inp)) {
        setError(inp, inp.parentNode.getAttribute('data-validate'));
        return false;
    } else if (inp.value.length < minLength) {
        setError(inp, `Requiere mínimo ${minLength} caracteres`);
        return false;
    } else if (inp.value.length > maxLength) {
        setError(inp, `Requiere máximo ${maxLength}`);
        return false;
    }
    return true;
}

function validateForm() {
    var one = validation(input[0], 4, 45),
        two = validation(input[1], 4, 45);
    return (one && two);
}

/*
validate -> verifica que contenga texto. {true si no hay texto, false si lo hay}
showClass -> agrega la clase css al element.
hideClass -> Elimina la clase css del element.
setError -> Agrega el sms al element.
validation -> cosa sucia para que el user vea sus cagadas.
testforeach 
*/