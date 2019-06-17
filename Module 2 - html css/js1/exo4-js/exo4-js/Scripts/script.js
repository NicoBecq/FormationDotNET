document.querySelector('#submit').addEventListener('click', function (e) {
    e.preventDefault();
    var regexFirstName = /[A-Za-záàâäãåçéèêëíìîïñóòôöõúùûüýÿæœ-_ç ]/;
    var regexLastNameCity = /[A-Za-záàâäãåçéèêëíìîïñóòôöõúùûüýÿæœ\-_ç ]/;
    let firstName = document.querySelector('#lastname').value;
    let lastName = document.querySelector('#firstname').value;
    let city = document.querySelector('#city').value;
    if (regexLetters.test(firstName) && regexLetters.test(lastName) && regexLetters.test(city)) {
        window.alert(`Nom: ${lastName}\nPrénom: ${firstName}\nVille: ${city}`);
    } else {
        window.alert('Veuillez saisir des noms valides');
    }
})