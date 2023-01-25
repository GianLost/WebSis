function RegisterSecretaryForm() {
  let properties = {
    Name: $("#sName").val(),
    Acronym: $("#sAcronym").val(),
  };
  $.post("/Secretaries/RegisterSecretaries", properties)

    .done(function (output) {
      if (output.stats == "OK") {
        setTimeout(function () {
          $("#msg-secretary")
            .html(
              '<div class="alert alert-success"> Secretaria Cadastrada com Sucesso ! </div>'
            )
            .fadeOut(5000);
        }, 80);
      }
    })

    .fail(function () {
      alert("Ocorreu um erro!");
    });
}

$(document).ready(function () {
  $("#sForm").submit(function (e) {
    e.preventDefault();
    RegisterSecretaryForm();
  });
});


function ValidateSecretaryForm() {
  secretaryName = $("#sName").val();
  secretaryAcronym = $("#sAcronym").val();

  if (secretaryName == "") {
    $("#msg-secretary").html(
      '<div class="alert alert-danger"> O campo nome da secretaria é obrigatório! </div>'
    );

    $("#sName").focus();
    return false;
  } else if (secretaryAcronym == "") {
    $("#msg-secretary").html(
      '<div class="alert alert-danger"> O campo sigla da secretaria é obrigatório! </div>'
    );

    $("#sAcronym").focus();
    return false;
  } else {
    return true;
  }
}
