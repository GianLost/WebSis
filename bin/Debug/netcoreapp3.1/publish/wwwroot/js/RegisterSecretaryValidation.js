
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

    alert("Secretaria cadastrada com sucesso !");
    
    return true;
  }
}
