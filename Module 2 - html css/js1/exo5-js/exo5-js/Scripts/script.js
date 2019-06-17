document.querySelector('#submit').addEventListener('click', function (e) {
    e.preventDefault();
    let firstNumber = parseInt(document.querySelector('#firstNumber').value, 10)
    let secondNumber = parseFloat(document.querySelector('#secondNumber').value, 10)
    if (isNaN(firstNumber) || isNaN(secondNumber)) {
        window.alert('Veuillez saisir des nombres svp');
    } else {
        let resultat = firstNumber * secondNumber;
        window.alert(`${firstNumber} multiplié par ${secondNumber} vaut: ${resultat.toFixed(2)}`);
    }
})