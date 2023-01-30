
$(function () {
  $(".av-btn").click(function (e) {
    e.preventDefault();
    el = $(this).data("element");
    $(el).toggle();
  });
});

$(function () {
  $(".rd-btn").click(function (e) {
    e.preventDefault();
    el = $(this).data("element");
    $(el).toggle();
  });
});

$(function () {
  $(".sa-btn").click(function (e) {
    e.preventDefault();
    el = $(this).data("element");
    $(el).toggle();
  });
});

$(function () {
  $(".rv-btn").click(function (e) {
    e.preventDefault();
    el = $(this).data("element");
    $(el).toggle();
  });
});








function getSecretariesProp() {
  var select = document.querySelector("#selectSecretary");
  var indice = select.selectedIndex;
  var option = select.options[indice];

  var teste = document.getElementById("secretaryName").value = option.text.split("-");

  document.getElementById("secretaryId").value = option.value;
  document.getElementById("secretaryName").value = teste[0];
}
getSecretariesProp();





function getIndexSecretariesProp() {
  var select = document.querySelector("#selectIndexSecretary");
  var indice = select.selectedIndex;
  var option = select.options[indice];

  document.getElementById("av-secretaryName").value = option.value;
  document.getElementById("rd-secretaryName").value = option.value;
  document.getElementById("sa-secretaryName").value = option.value;
  document.getElementById("rv-secretaryName").value = option.value;
}
getIndexSecretariesProp();

















function Calc() {
const date1 = new Date(document.getElementById('date1').value);
const date2 = new Date(document.getElementById('date2').value);

let start = Math.floor(date1.getTime() / (3600 * 24 * 1000));
let end = Math.floor(date2.getTime() / (3600 * 24 * 1000));
let daysDiff = end - start;

document.getElementById('n1').value = daysDiff + 1;
document.getElementById('n3').value = daysDiff + 1;

Date.prototype.addDays = function(days) 
{
  return this.setDate(this.getDate() + days);
}

if (date2 < date1)
{
  alert( "a data de chegada precisa ser igual ou posterior a data de saída !");
  document.getElementById('date3').value = "dd/mm/aaaa";  
  return false;
}else{
  let date = new Date(date2);

  date.addDays(15);

  document.getElementById('date3').value = date.toLocaleDateString('pt-BR');  
}

}