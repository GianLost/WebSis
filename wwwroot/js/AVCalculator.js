/*function FormatDateInputs() {
    // calcula o total em R$ do custo de alimentação e hospedagem de acordo com foodQtd * foodValue = totalFood e o mesmo para hospedagem e dps utiliza os dois totais para calcular o valor total de despesas. foodTotal + hostTotal = totalExpanses;
    $('.date-first').keyup(function (e) {

        $(this).val($(this).val().replace(/\D/g, '').replace(/(\d{2})(\d{2})(\d{4})$/, "$1/$2/$3"));
    }
)};

FormatDateInputs();*/

function FormatDoubleInputs() {
    // calcula o total em R$ do custo de alimentação e hospedagem de acordo com foodQtd * foodValue = totalFood e o mesmo para hospedagem e dps utiliza os dois totais para calcular o valor total de despesas. foodTotal + hostTotal = totalExpanses;
    $('.double-first').keyup(function (e) {

        $(this).val($(this).val().replace(/\D/g, '').replace(/(\d{1})(\d{2})$/, "$1,$2"));
    }
)};

FormatDoubleInputs();

function SA() {

    // calcula o total em R$ do custo de alimentação e hospedagem de acordo com foodQtd * foodValue = totalFood e o mesmo para hospedagem e dps utiliza os dois totais para calcular o valor total de despesas. foodTotal + hostTotal = totalExpanses;

    $('.money-input').keyup(function (e) {

        $(this).val($(this).val().replace(/\D/g, '').replace(/(\d{1})(\d{1,2})$/, "$1,$2").replace(/(\d)(?=(\d{3})+(?!\d))/g, '$1'));

        let n1 = document.getElementById('n1').value;
        let n2 = parseFloat(document.getElementById('n2').value).toFixed(2);
        let n3 = document.getElementById('n3').value;
        let n4 = parseFloat(document.getElementById('n4').value).toFixed(2);

        let result = document.getElementById('totalfood').value = (n1 * parseFloat(n2)).toLocaleString('pt-br', {minimumFractionDigits: 2});
        let result2 = document.getElementById('totalhosting').value = (n3 * parseFloat(n4)).toLocaleString('pt-br', {minimumFractionDigits: 2});

        document.getElementById('total').value = (parseInt(result) + parseFloat(result2)).toLocaleString('pt-br', {minimumFractionDigits: 2});
    
    })
}

SA();


function upSA() {

    // calcula o total em R$ do custo de alimentação e hospedagem de acordo com foodQtd * foodValue = totalFood e o mesmo para hospedagem e dps utiliza os dois totais para calcular o valor total de despesas. foodTotal + hostTotal = totalExpanses;
    
    $('.values-input').keyup(function (e) {

        $(this).val($(this).val().replace(/\D/g, '').replace(/(\d{1})(\d{1,2})$/, "$1.$2"));

        let upn1 = document.getElementById('upn1').value;
        let upn2 = document.getElementById('upn2').value;
        let upn3 = document.getElementById('upn3').value;
        let upn4 = document.getElementById('upn4').value;

        let upresult = document.getElementById('uptotalfood').value = (upn1 * upn2).toFixed(2);
        let upresult2 = document.getElementById('uptotalhosting').value = (upn3 * upn4).toFixed(2);

        document.getElementById('uptotal').value = (parseFloat(upresult) + parseFloat(upresult2)).toFixed(2);
        
    })
}

upSA();
