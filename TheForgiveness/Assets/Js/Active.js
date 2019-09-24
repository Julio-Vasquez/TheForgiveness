const selected = document.querySelectorAll('.sbitem');
for (let i = 0; i < selected.length; i++) {//add event
    selected[i].addEventListener("click", function () {//lo que hace el evento
        for (let j = 0; j < selected.length; j++)
            selected[j].classList.remove('selected');
        this.classList.add('selected');
    });
}

const selected2 = document.querySelectorAll('.sbitem2');
for (let i = 0; i < selected2.length; i++) {//add event
    selected2[i].classList.remove('selected');
    if (selected2[i].classList.remove('active')) {
        selected2[i].classList.add('selected');
    }
}