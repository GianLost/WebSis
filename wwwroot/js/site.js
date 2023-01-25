// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
/*$(function() {
    $(".btn-toggle").click(function(e) {
      e.preventDefault();
      el = $(this).data('element');
      $(el).toggle();
    });
  });*/

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

  document.getElementById("secretaryId").value = option.value;
  document.getElementById("secretaryName").value = option.text;
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
