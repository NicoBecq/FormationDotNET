$(document).ready(function () {
    var count = 0; // initialisation d'un compteur stocké dans la variable count
    // lorsqu'on clique sur le bouton "incrémenter", incrémenter le compteur et remplacer la valeur du champ par la valeur du compteur.
    $('#button').click(function () {
        count++;
        $('#counter').val(count);
    });
});