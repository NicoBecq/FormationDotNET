$(document).ready(function () {
    // lorsque le DOM finit de charger, afficher les règles
    alert('Bonjour!\nEssayez de deviner un nombre choisi aléatoirement entre 1 et 100.\nEntrez le nombre dans le champ prévu a cet effet.');
    // génération d'un entier aléatoire compris entre 1 et 100 stocké dans la variable random
    var random = Math.floor(Math.random() * Math.floor(101));
    // initialisation d'un compteur pour le nombre d'essais
    var counter = 0;
    console.log(random);
    // lorsqu'on clicque sur le bouton envoyer, on effectue les test suivants:
    $('#submit').click(function () {
        var userInput = $('#userInput').val(); // stockage de l'entrée utilisateur
        // Si userInput est un nombre et est compris entre 1 et 100, on effectue la suite des vérifications, sinon ce n'est pas un nombre donc afficher message d'erreur
        if (!isNaN(parseInt(userInput)) && userInput <= 100 && userInput > 0) {
            // Si userInput est différent du nbre à deviner, alerter si c'est plus grand ou plus petit
            if (userInput != random) {
                counter++; // incrémentation du compteur d'essais
                if (userInput > random) {
                    alert('C\'est plus petit');
                } else if (userInput < random) {
                    alert('C\'est plus grand');
                }
                // Sinon, si userInput est égale au nbre à devnier, alors c'est gagné
            } else if (userInput == random) {
                alert(`Bravo, vous avez trouvé!\nLe nombre à deviner était ${random}, et vous l'avez trouvé en ${counter} essais.`);
            }
        } else {
            alert(`Veuillez entrer un nombre`);
        }
    });
});