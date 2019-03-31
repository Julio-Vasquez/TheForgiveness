const selected = document.querySelectorAll('.sbitem');
for (let i = 0; i < selected.length; i++) {//add event
    selected[i].addEventListener("click", function () {//lo que hace el evento
        for (let j = 0; j < selected.length; j++)
            selected[j].classList.remove('selected');
        this.classList.add('selected');
    });
}