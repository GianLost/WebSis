function RegisterUserForm() {
  let properties = {
    Name: $("#name").val(),
    Login: $("#login").val(),
    Password: $("#password").val(),
    CheckedPassword: $("#checkedPassword").val(),
    Type: $("#type").val(),
    SecretariesId: $("#seclectUserRegister").val(),
  };
  $.post("/Users/RegisterUser", properties)

    .done(function (output) {
      if (output.stats == "OK") {
        setTimeout(function () {
          $("#msg")
            .html(
              '<div class="alert alert-success"> Cadastro realizado com Sucesso! </div>'
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
  $("#formUser").submit(function (e) {
    e.preventDefault();
    RegisterUserForm();
  });
});

function FormValidate() {
  Name = $("#name").val();
  Login = $("#login").val();
  Password = $("#password").val();
  CheckedPassword = $("#checkedPassword").val();
  Type = $("#type").val();

  if (Name == "") {
    $("#msg").html(
      '<div class="alert alert-danger"> O campo Nome é obrigatório! </div>'
    );

    $("#name").focus();
    return false;
  } else if (Login == "") {
    $("#msg").html(
      '<div class="alert alert-danger"> O campo Login é obrigatório! </div>'
    );

    $("#login").focus();
    return false;
  } else if (Password == "") {
    $("#msg").html(
      '<div class="alert alert-danger"> O campo Senha é obrigatório! </div>'
    );

    $("#password").focus();
    return false;
  } else if (CheckedPassword == "") {
    $("#msg").html(
      '<div class="alert alert-danger"> O campo Confirmar Senha é obrigatório! </div>'
    );

    $("#checkedPassword").focus();
    return false;
  } else if (Password != CheckedPassword) {
    $("#msg").html(
      '<div class="alert alert-danger"> As senhas não são idênticas! </div>'
    );

    $("#checkedPassword").focus();
    return false;
  }else if (Password.length <= 7 || CheckedPassword.length <= 7 ) {
    $("#msg").html(
      '<div class="alert alert-danger"> As senhas precisam ter no mínimo 8 caracteres! </div>'
    );

    $("#password").focus();
    return false;
  } else if (document.formUser.type.options[type.selectedIndex].value == -1) {
    $("#msg").html(
      '<div class="alert alert-danger"> O campo Tipo é obrigatório! </div>'
    );

    $("#type").focus();
    return false;

  }else if (document.formUser.seclectUserRegister.options[seclectUserRegister.selectedIndex].value == -1) {
    $("#msg").html(
      '<div class="alert alert-danger"> Selecione uma Secretaria! </div>'
    );

    $("#seclectUserRegister").focus();
    return false;

  } else {

    return true;
    
  }
}
