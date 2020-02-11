let inpHidden = document.getElementById("Experiencia");
//get elements 0 & 1
const lugar = document.querySelectorAll(".ulli ul li label img");

let textLugar = "",
  textActor = "",
  textSuceso = "",
  textMotivo = "";

window.onload = () => {
  for (let i = 0; i < lugar.length; i++) {
    lugar[i].addEventListener("click", () => {
      if (i < 2) {
        textLugar = lugar[i].getAttribute("alt");
      } else if (i > 1 && i < 8) {
        textActor = " " + lugar[i].getAttribute("alt");
      } else if (i > 7 && i < 12) {
        textSuceso = " " + lugar[i].getAttribute("alt");
      } else {
        textMotivo = " " + lugar[i].getAttribute("alt");
      }
    });
  }
};

const saveTextFinal = e => {
  e.preventDefault();
  inpHidden.value = textLugar + textActor + textSuceso + textMotivo;
  //document.getElementById("btnExperience").submit();
  console.log(inpHidden.value);
}
