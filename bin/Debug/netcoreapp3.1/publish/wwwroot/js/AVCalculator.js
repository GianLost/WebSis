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

        $(this).val($(this).val().replace(/\D/g, '').replace(/(\d{1})(\d{1,2})$/, "$1.$2").replace(/(\d)(?=(\d{3})+(?!\d))/g, '$1'));

        function getMoney(str) {
            return parseFloat(str.replace(/[^\d,]/g, '').replace(/(\d{1})(\d{1,2})$/, "$1.$2").replace(/(\d)(?=(\d{3})+(?!\d))/g, '$1')).toFixed(+2);
        }

        let foodQtd = document.getElementById('n1').value;
        let foodUnitaryValue = document.getElementById('n2').value;
        
        let hostQtd = document.getElementById('n3').value;
        let hostUnitaryValue = document.getElementById('n4').value;

        let convertFoodValue = getMoney(foodUnitaryValue); 

        let convertHostValue = getMoney(hostUnitaryValue); 
        let totalOfFood = foodQtd * convertFoodValue; 

        document.getElementById('totalfood').value = totalOfFood.toFixed(2) 

        let totalOfHost = hostQtd * convertHostValue; 

        document.getElementById('totalhosting').value = totalOfHost.toFixed(2); 

        let totalExpanses = totalOfFood + totalOfHost; 

        document.getElementById('total').value = totalExpanses.toFixed(2);

    })
}

SA();

function upSA() {

    // calcula o total em R$ do custo de alimentação e hospedagem de acordo com foodQtd * foodValue = totalFood e o mesmo para hospedagem e dps utiliza os dois totais para calcular o valor total de despesas. foodTotal + hostTotal = totalExpanses;

    $('.values-input').keyup(function (e) {

        $(this).val($(this).val().replace(/\D/g, '').replace(/(\d{1})(\d{1,2})$/, "$1.$2").replace(/(\d)(?=(\d{3})+(?!\d))/g, '$1'));

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

        document.getElementById('uptotalfood').value = totalOfFood;
        document.getElementById('uptotalhosting').value = totalOfHost;

        let totalExpanses = totalOfFood + totalOfHost;

        let totalExpansesConvert = formatReal(totalExpanses);
        document.getElementById('uptotal').value = totalExpansesConvert;

        console.log('Tipo de dado: ' + typeof (formatReal(totalExpansesConvert)) + ' | totalExpansesConvert: ' + formatReal(totalExpansesConvert));

    })
}

upSA();
