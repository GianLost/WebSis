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

        document.getElementById('totalfood').value = totalOfFood; // number
        console.log(typeof(totalOfFood) + ' | INPUT totalFood: ' + totalOfFood);

        let totalOfHost = hostQtd * convertHostValue; // number
        console.log(typeof(totalOfHost) + ' | totalOfHost: ' + totalOfHost);

        document.getElementById('totalhosting').value = totalOfHost; // number
        console.log(typeof(totalOfHost) + ' | INPUT totalHost: ' + totalOfHost);

        let totalExpanses = totalOfFood + totalOfHost; // number
        console.log(typeof(totalExpanses) + ' | totalExpanses: ' + totalExpanses);

        //let totalExpansesConvert = totalExpanses;
        //console.log(typeoftotalExpansesConvert + ' | totalExpansesConvert: ' + totalExpansesConvert);

        document.getElementById('total').value = totalExpanses.toFixed(2);
        console.log('Tipo de dado: ' + typeof (totalExpanses) + ' | INPUT totalExpansesConvert: ' + totalExpanses);

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
