$(document).ready(function () {
    var choices = ['pierre', 'feuille', 'ciseaux']; // coups dispos
    var icoChoices = ['far fa-hand-rock fa-2x', 'far fa-hand-paper fa-2x', 'far fa-hand-scissors fa-2x']; // icones relatives aux choix de coups
    var userScore = 0;
    var iaScore = 0;
    var toggleStats = function (userScore, iaScore, userChoice, iaChoice, winOrLoose) {
        $('#userScore').text(`${userScore}`); // afficher score
        $('#iaScore').text(`${iaScore}`); // afficher score
        $('#userChoice').attr('class', icoChoices[userChoice]); // afficher icones choix
        $('#iaChoice').attr('class', icoChoices[iaChoice]); // afficher icones choix
        $('#resume').text(`Vous avez joué ${choices[userChoice]}, l'ia a joué ${choices[iaChoice]}, vous avez donc ${winOrLoose}.`);
        $('#score').text(`Vous avez ${userScore} points, l'ia a ${iaScore} points.`);
        $('#percent').text(`Vous gagnez ${calcPercent(userScore, iaScore)}% de vos coups contre l'ia.`);
    };
    var calcPercent = function (userScore, iaScore) {
        var percent = 100 * (userScore / (userScore + iaScore));
        return Math.round(percent);
    };
    $('#submit').click(function () {
        // Si un des coup est choisi 
        if ($('#rock').is(':checked') || $('#paper').is(':checked') || $('#scissors').is(':checked')) {
            $('#playArea').removeAttr('hidden'); // afficher l'ère de jeu
            var random = Math.floor(Math.random() * Math.floor(3)); // générer le coup de l'ia via un nombre aléatoire compris entre 0 et 2 inclus
            var userChoice = $('input:checked').val();
            if ((userChoice == 0 && random == 1) || (userChoice == 1 && random == 2) || (userChoice == 2 && random == 0)) { // ia gagne
                iaScore++;
                toggleStats(userScore, iaScore, userChoice, random, 'perdu');
            } else if ((random == 0 && userChoice == 1) || (random == 1 && userChoice == 2) || (random == 2 && userChoice == 0)) {
                userScore++;
                toggleStats(userScore, iaScore, userChoice, random, 'gagné');
            } else if (userChoice == choices[random]) { // égalité
                $('#resume').text('Egalité');
            }
        } else { // sinon alerter qu'il faut choisir un coup pour jouer
            alert('Veuillez choisir un coup pour affronter l\'ia au shifumi.');
        }
    });
});