function FormatDoubleInputs() {
    // calcula o total em R$ do custo de alimentação e hospedagem de acordo com foodQtd * foodValue = totalFood e o mesmo para hospedagem e dps utiliza os dois totais para calcular o valor total de despesas. foodTotal + hostTotal = totalExpanses;
    $('.double-first').keyup(function (e) {

        $(this).val($(this).val().replace(/\D/g, '').replace(/(\d{1})(\d{2})$/, "$1,$2"));
    }
    )
};

FormatDoubleInputs();

function SA() {

    // calcula o total em R$ do custo de alimentação e hospedagem de acordo com foodQtd * foodValue = totalFood e o mesmo para hospedagem e dps utiliza os dois totais para calcular o valor total de despesas. foodTotal + hostTotal = totalExpanses;

    $('.money-input').keyup(function (e) {

        $(this).val($(this).val().replace(/\D/g, '').replace(/(\d{1})(\d{1,2})$/, "$1,$2").replace(/(\d)(?=(\d{3})+(?!\d))/g, '$1'));

        function getMoney(str) {
            return str.replace(/[^\d,]/g, '').replace(',', '.');
        }

        function formatReal(realValue) {
            return realValue.toLocaleString('pt-br', { minimumFractionDigits: 2 });
        }

        let foodQtd = document.getElementById('n1').value;
        let foodUnitaryValue = document.getElementById('n2').value;
        
        let hostQtd = document.getElementById('n3').value;
        let hostUnitaryValue = document.getElementById('n4').value;

        /*let convertFoodQtd = parseInt(foodQtd);
        console.log(typeof(convertFoodQtd) + ' | convertFoodQtd: ' + convertFoodQtd);
        let convertHostQtd = parseInt(hostQtd);
        console.log(typeof(convertHostQtd) + ' | convertHostQtd: ' + convertHostQtd);*/

        let convertFoodValue = getMoney(foodUnitaryValue); //string
        console.log(typeof(getMoney(convertFoodValue)) + ' | convertFoodValue: ' + getMoney(convertFoodValue));

        let convertHostValue = getMoney(hostUnitaryValue); //string
        console.log(typeof(getMoney(convertHostValue)) + ' | convertHostValue: ' + getMoney(convertHostValue));

        let totalOfFood = foodQtd * convertFoodValue; // number
        console.log(typeof(totalOfFood) + ' | totalOfFood: ' + totalOfFood);

        document.getElementById('totalfood').value = formatReal(totalOfFood); // number
        console.log(typeof(totalOfFood) + ' | INPUT totalFood: ' + totalOfFood);

        let totalOfHost = hostQtd * convertHostValue; // number
        console.log(typeof(totalOfHost) + ' | totalOfHost: ' + totalOfHost);

        document.getElementById('totalhosting').value = formatReal(totalOfHost); // number
        console.log(typeof(totalOfHost) + ' | INPUT totalHost: ' + totalOfHost);

        let totalExpanses = totalOfFood + totalOfHost; // number
        console.log(typeof(totalExpanses) + ' | totalExpanses: ' + totalExpanses);

        //let totalExpansesConvert = totalExpanses;
        //console.log(typeoftotalExpansesConvert + ' | totalExpansesConvert: ' + totalExpansesConvert);

        document.getElementById('total').value = formatReal(totalExpanses);
        console.log('Tipo de dado: ' + typeof (totalExpanses) + ' | INPUT totalExpansesConvert: ' + totalExpanses);

    })
}

SA();

function upSA() {

    // calcula o total em R$ do custo de alimentação e hospedagem de acordo com foodQtd * foodValue = totalFood e o mesmo para hospedagem e dps utiliza os dois totais para calcular o valor total de despesas. foodTotal + hostTotal = totalExpanses;

    $('.values-input').keyup(function (e) {

        $(this).val($(this).val().replace(/\D/g, '').replace(/(\d{1})(\d{1,2})$/, "$1.$2").replace(/(\d)(?=(\d{3})+(?!\d))/g, '$1'));

        function getMoney(str) {
            return str.replace(/[^\d,]/g, '').replace(',', '.');
        }

        function formatReal (formatValue)
        {
            return formatValue.toLocaleString('pt-br', {minimumFractionDigits : 2 });
        }

        let foodQtd = document.getElementById('upn1').value;
        let foodUnitaryValue = document.getElementById('upn2').value;

        let hostQtd = document.getElementById('upn3').value;
        let hostUnitaryValue = document.getElementById('upn4').value;

        let convertFoodValue = getMoney(foodUnitaryValue);
        let convertHostValue = getMoney(hostUnitaryValue);

        let totalOfFood = foodQtd * convertFoodValue;

        document.getElementById('uptotalfood').value = formatReal(totalOfFood);

        let totalOfHost = hostQtd * convertHostValue;

        document.getElementById('uptotalhosting').value = formatReal(totalOfHost);

        let totalExpanses = totalOfFood + totalOfHost;

        document.getElementById('uptotal').value = formatReal(totalExpanses);

    })
}

upSA();
