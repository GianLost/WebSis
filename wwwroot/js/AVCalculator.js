function SA() {
    $('.values-input').keyup(function (e) {
       $(this).val($(this).val().replace(/\D/g,'').replace(/(\d{1})(\d{1,2})$/, "$1.$2"));
    var n1 = document.getElementById('n1').value;
    var n2 = document.getElementById('n2').value;

    var n3 = document.getElementById('n3').value;
    var n4 = document.getElementById('n4').value;

    var result = document.getElementById('totalfood').value = (n1 * n2).toFixed(2);

    var result2 = document.getElementById('totalhosting').value = (n3 * n4).toFixed(2);

    document.getElementById('total').value = (parseFloat(result) + parseFloat(result2)).toFixed(2);
    }
)}

SA();