document.querySelector('#submit').addEventListener('click', function (e) {
    e.preventDefault();
    let shoeSize = parseFloat(document.querySelector('#shoeSize').value);
    let yearOfBirth = document.querySelector('#yearOfBirth').value;
    if (!isNaN(shoeSize)) {
        if (!isNaN(yearOfBirth) && yearOfBirth.length == 4) {
            yearOfBirth = parseInt(yearOfBirth);
            let resultat;
            resultat = shoeSize * 2;
            resultat += 5;
            resultat *= 50;
            resultat -= yearOfBirth;
            resultat += 1769;
            window.alert(`${resultat}`);
        } else {
            window.alert('Veuillez saisir une année de naissance valide');
        }
    } else {
        window.alert('Veuillez saisir une pointure valide');
    }
});