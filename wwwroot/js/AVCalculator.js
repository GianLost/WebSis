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
        console.log('Numero 1: ' + n1); //qtd

        let n2 = document.getElementById('n2').value;
        console.log('Numero 2: ' + n2); //value

        let n3 = document.getElementById('n3').value;
        console.log('Numero 3: ' + n3);// qtd

        let n4 = document.getElementById('n4').value;
        console.log('Numero 4: ' + n4); //value

        let n2Convert = parseFloat(n2).toFixed(2);
        console.log('n2Convert: ' + n2Convert)

        let n4Convert = parseFloat(n4).toFixed(2);
        console.log('n4Convert: ' + n4Convert)

        let totalFood = parseInt(n1) * parseFloat(n2Convert).toFixed(2).toLocaleString('pt-br', {minimumFractionDigits: 2});
        console.log('TotalFood: ' + totalFood);

        let totalHosting = parseInt(n3) * parseFloat(n4Convert).toFixed(2).toLocaleString('pt-br', {minimumFractionDigits: 2});
        console.log('totalHosting: ' + totalHosting);

        let resultFood = document.getElementById('totalfood').value = totalFood.toFixed(2).replace(/\D/g, '').replace(/(\d{1})(\d{1,2})$/, "$1,$2").replace(/(\d)(?=(\d{3})+(?!\d))/g, '$1');
        console.log('resultFood: ' + resultFood);

        let resultHost = document.getElementById('totalhosting').value = totalHosting.toFixed(2).replace(/\D/g, '').replace(/(\d{1})(\d{1,2})$/, "$1,$2").replace(/(\d)(?=(\d{3})+(?!\d))/g, '$1');
        console.log('resultHost: ' + resultHost);

        let total = parseInt(resultFood) + parseInt(resultHost);
        console.log('Total: ' + total);

        document.getElementById('total').value = parseFloat(total).toFixed(2).replace(/\D/g, '').replace(/(\d{1})(\d{1,2})$/, "$1,$2").replace(/(\d)(?=(\d{3})+(?!\d))/g, '$1.');
    
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
