$(document).ready(function () {
    var square = $('#square');
    // height ET SI height > 100px, repasser à la valeur de base (10px)
    $('#height').click(function () {
        var actualHeight = square.height();
        actualHeight = actualHeight + 10; // ajouter 10px à la hauteur actuelle
        // si la hauteur actuelle est inférieure à 100px augmenter de 10 px, sinon si la hauteur actuelle est supérieure ou égale à 100px, repasser a 10px
        if (actualHeight < 100) {
            square.height(actualHeight);
        } else {
            square.height(10);
        }
    });
    //Couleur verte
    $('#green').click(function () {
        square.addClass('square_green');
    });
    //Couleur de base
    $('#classic_color').click(function () {
        square.removeClass('square_green');
    });
    //hide cacher 
    $('#hide').click(function () {
        square.hide();
    });
    //show
    $('#show').click(function () {
        square.show();
    });
});