$(document).ready(function () {
    $('#osef').keydown(function () {
        var screenWidth = $(window).width(); //stockage de la largeur de l'écran
        var screenWidthSquareIncluded = screenWidth - 30; // stockage de la largeur de l'écran moins la taille du carré
        var screenHeight = $(window).height(); // stockage de la hauteur de l'écran
        var screenHeightSquareIncluded = screenHeight - 30; // stockage de la hauteur de l'écran moins la taille du carré
        var actualPosition = $('#square').position(); // stockage de la position du carré
        var futurePosition; // initialisation d'un variable qui aura la valeur de la position en fonction de la touche appuyée
        // Si le keyCode vaut 37 go à gauche
        if (event.keyCode == 37) {
            // Si la position actuelle vaut 0 (a gauche), lui donner la valeur window.witdh - sa taille
            if (actualPosition.left == 0) {
                futurePosition = screenWidth - 30;
                $('#square').css('left', futurePosition);
            } else {    // Sinon déplacer de 10
                futurePosition = actualPosition.left - 10;
                $('#square').css('left', futurePosition);
            }
        } else if (event.keyCode == 38) {       // Sinon si le keyCode vaut 38, go en haut
            // Si la position actuelle vaut 0 (en haut), lui donner window.height - sa taille
            if (actualPosition.top <= 0) {
                futurePosition = screenHeight - 30;
                $('#square').css('top', futurePosition);
            } else {    // Sinon déplacer de 10
                futurePosition = actualPosition.top - 10;
                $('#square').css('top', futurePosition);
            }
        } else if (event.keyCode == 39) {       // Sinon si le keyCode vaut 39, go a droite
            // Si la position actuelle vaut largeur de l'écran square included, passer de l'autre côté
            if (actualPosition.left >= screenWidthSquareIncluded) {
                $('#square').css('left', '0');
            } else {    // Sinon, déplacer de 10px
                futurePosition = actualPosition.left + 10;
                $('#square').css('left', futurePosition);
            }
        } else if (event.keyCode == 40) {       // Sinon si le keyCode vaut 40, go en bas
            // Si la position actuelle vaut la hauteur de l'écran square included (en bas), passer de l'autre côté
            if (actualPosition.top >= screenHeightSquareIncluded) {
                $('#square').css('top', '0');
            } else {    //Sinon déplacer de 10px;
                futurePosition = actualPosition.top + 10;
                $('#square').css('top', futurePosition);
            }
        } else {    // sinon empécher la saisie et rappel des règles
            event.preventDefault();
            alert('appuyez sur une flèche directionnelle pour faire bouger le carré rouge');
        }
    });
});