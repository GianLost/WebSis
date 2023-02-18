
function ShowModules(id) {

  // exibe e esconde as divs dos módulos de AV,RD,SA e RV

  if (document.getElementById(id).style.display !== "none") {
    document.getElementById(id).style.display = "none";
    return;
  }
  Array.from(document.getElementsByClassName("hidden")).forEach(
    div => (div.style.display = "none")
  );
  document.getElementById(id).style.display = "block";

}

function getSecretariesProp() {

  let select = document.querySelector("#selectSecretary");
  let indice = select.selectedIndex;
  let option = select.options[indice];

  let teste = document.getElementById("secretaryName").value = option.text.split("-");

  document.getElementById("secretaryId").value = option.value;
  document.getElementById("secretaryName").value = teste[0];

}

getSecretariesProp();

function getIndexSecretariesProp() {

  // retorna para dentro da div dos módulos de acesso o nome da secretaria relacionada ao usuário atraves de um combobox select, 

  let select = document.querySelector("#selectIndexSecretary");
  let indice = select.selectedIndex;
  let option = select.options[indice];

  document.getElementById("av-secretaryName").value = option.value;
  document.getElementById("rd-secretaryName").value = option.value;
  document.getElementById("sa-secretaryName").value = option.value;
  document.getElementById("rv-secretaryName").value = option.value;
}

getIndexSecretariesProp();

function getUpSecretariesProp() {

  let upselect = document.querySelector("#upSelectSecretary");
  let upindice = upselect.selectedIndex;
  let upoption = upselect.options[upindice];

  let upteste = document.getElementById("upSecretaryName").value = upoption.text.split("-");

  document.getElementById("upSecretaryId").value = upoption.value;
  document.getElementById("upSecretaryName").value = upteste[0];


}

getUpSecretariesProp();


function Calc() {
  const date1 = new Date(document.getElementById('date1').value);
  const date2 = new Date(document.getElementById('date2').value);

  let start = Math.floor(date1.getTime() / (3600 * 24 * 1000));
  let end = Math.floor(date2.getTime() / (3600 * 24 * 1000));
  let daysDiff = end - start;

  document.getElementById('n1').value = daysDiff + 1;
  document.getElementById('n3').value = daysDiff + 1;

  Date.prototype.addDays = function (days) {
    return this.setDate(this.getDate() + days);
  }

  if (date2 < date1) {
    alert("a data de chegada precisa ser igual ou posterior a data de saída !");
    document.getElementById('date3').value = "dd/mm/aaaa";
    return false;
  } else {
    let date = new Date(date2);

    date.addDays(15);

    document.getElementById('date3').value = date.toLocaleDateString('pt-BR');
  }

}

function upCalc() {

  const update1 = new Date(document.getElementById('update1').value);
  const update2 = new Date(document.getElementById('update2').value);

  let upstart = Math.floor(update1.getTime() / (3600 * 24 * 1000));
  let upend = Math.floor(update2.getTime() / (3600 * 24 * 1000));
  let updaysDiff = upend - upstart;

  document.getElementById('upn1').value = updaysDiff + 1;
  document.getElementById('upn3').value = updaysDiff + 1;

  Date.prototype.addDays = function (days) {
    return this.setDate(this.getDate() + days);
  }

  if (update2 < update1) {
    alert("a data de chegada precisa ser igual ou posterior a data de saída !");
    document.getElementById('update3').value = "dd/mm/aaaa";
    return false;
  } else {

    let update = new Date(update2);

    update.addDays(15);

    document.getElementById('update3').value = update.toLocaleDateString('pt-BR');
  }

}

