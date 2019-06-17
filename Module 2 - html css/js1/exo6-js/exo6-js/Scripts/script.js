function modulo() {
    let firstNumber = parseFloat(document.querySelector('#firstNumber').value);
    let secondNumber = parseFloat(document.querySelector('#secondNumber').value);
    if (isNaN(firstNumber) || isNaN(secondNumber)) {
        window.alert('Veuillez saisir des nombres svp');
    } else {
        let resultat = firstNumber % secondNumber;
        window.alert(`${resultat}`);
    }
}