function SA() {
    // calcula o total em R$ do custo de alimentação e hospedagem de acordo com foodQtd * foodValue = totalFood e o mesmo para hospedagem e dps utiliza os dois totais para calcular o valor total de despesas. foodTotal + hostTotal = totalExpanses;
    $('.values-input').keyup(function (e) {

        $(this).val($(this).val().replace(/\D/g, '').replace(/(\d{1})(\d{1,2})$/, "$1.$2"));

        let n1 = document.getElementById('n1').value;
        let n2 = document.getElementById('n2').value;

        let n3 = document.getElementById('n3').value;
        let n4 = document.getElementById('n4').value;

        let result = document.getElementById('totalfood').value = (n1 * n2).toFixed(2);

        let result2 = document.getElementById('totalhosting').value = (n3 * n4).toFixed(2);

        document.getElementById('total').value = (parseFloat(result) + parseFloat(result2)).toFixed(2);
        
    })
}

SA();