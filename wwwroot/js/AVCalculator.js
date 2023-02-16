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

        $(this).val($(this).val().replace(/\D/g, '').replace(/(\d{1})(\d{2})$/, "$1.$2"));
    }
    )
};

FormatDoubleInputs();

function SA() {

    // calcula o total em R$ do custo de alimentação e hospedagem de acordo com foodQtd * foodValue = totalFood e o mesmo para hospedagem e dps utiliza os dois totais para calcular o valor total de despesas. foodTotal + hostTotal = totalExpanses;

    $('.money-input').keyup(function (e) {

        $(this).val($(this).val().replace(/\D/g, '').replace(/(\d{1})(\d{1,2})$/, "$1,$2").replace(/(\d)(?=(\d{3})+(?!\d))/g, '$1.'));

        function getMoney(str) {
            let clearStr = str.replace(/[^\d,]/g, '');
            clearStr = clearStr.replace(',', '.');
            return parseFloat(clearStr);

        }

        function formatReal(realValue) {
            return realValue.toLocaleString('pt-br', { minimumFractionDigits: 2 });
        }

        let foodQtd = document.getElementById('n1').value;
        let hostQtd = document.getElementById('n3').value;

        let foodUnitaryValue = document.getElementById('n2').value;
        let hostUnitaryValue = document.getElementById('n4').value;

        let convertFoodQtd = parseInt(foodQtd);
        let convertHostQtd = parseInt(hostQtd);

        let convertFoodValue = getMoney(foodUnitaryValue);
        let convertHostValue = getMoney(hostUnitaryValue);

        let totalOfFood = convertFoodQtd * convertFoodValue;
        let totalOfHost = convertHostQtd * convertHostValue;

        document.getElementById('totalfood').value = formatReal(totalOfFood);
        document.getElementById('totalhosting').value = formatReal(totalOfHost);

        let totalExpanses = totalOfFood + totalOfHost;

        let totalExpansesConvert = formatReal(totalExpanses);
        document.getElementById('total').value = totalExpansesConvert;

        console.log('Tipo de dado: ' + typeof (formatReal(totalExpansesConvert)) + ' | totalExpansesConvert: ' + formatReal(totalExpansesConvert));

    })
}

SA();

function upSA() {

    // calcula o total em R$ do custo de alimentação e hospedagem de acordo com foodQtd * foodValue = totalFood e o mesmo para hospedagem e dps utiliza os dois totais para calcular o valor total de despesas. foodTotal + hostTotal = totalExpanses;

    $('.values-input').keyup(function (e) {

        $(this).val($(this).val().replace(/\D/g, '').replace(/(\d{1})(\d{1,2})$/, "$1,$2").replace(/(\d)(?=(\d{3})+(?!\d))/g, '$1.'));

        function getMoney(str) {
            let clearStr = str.replace(/[^\d,]/g, '');
            clearStr = clearStr.replace(',', '.');
            return parseFloat(clearStr);

        }

        function formatReal(realValue) {
            return realValue.toLocaleString('pt-br', { minimumFractionDigits: 2 });
        }

        let foodQtd = document.getElementById('upn1').value;
        let hostQtd = document.getElementById('upn3').value;

        let foodUnitaryValue = document.getElementById('upn2').value;
        let hostUnitaryValue = document.getElementById('upn4').value;

        let convertFoodQtd = parseInt(foodQtd);
        let convertHostQtd = parseInt(hostQtd);

        let convertFoodValue = getMoney(foodUnitaryValue);
        let convertHostValue = getMoney(hostUnitaryValue);

        let totalOfFood = convertFoodQtd * convertFoodValue;
        let totalOfHost = convertHostQtd * convertHostValue;

        document.getElementById('uptotalfood').value = formatReal(totalOfFood);
        document.getElementById('uptotalhosting').value = formatReal(totalOfHost);

        let totalExpanses = totalOfFood + totalOfHost;

        let totalExpansesConvert = formatReal(totalExpanses);
        document.getElementById('uptotal').value = totalExpansesConvert;

        console.log('Tipo de dado: ' + typeof (formatReal(totalExpansesConvert)) + ' | totalExpansesConvert: ' + formatReal(totalExpansesConvert));

    })
}

upSA();
