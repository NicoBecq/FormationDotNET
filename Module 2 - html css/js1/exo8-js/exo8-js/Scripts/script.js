document.querySelector('#submit').addEventListener('click', function (e) {
    let age = parseInt(document.querySelector('#age').value);
    if (!isNaN(age) && age > 0 && age < 120) {
        if (age >= 18) {
            window.alert('Vous êtes majeur');
        } else if (age < 18) {
            window.alert('Vous êtes mineur');
        }
    } else {
        window.alert('Veuillez saisir un nombre valide svp');
    }
});