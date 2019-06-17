$(document).ready(function () {
    var count = 0;  // initialisation d'un compteur stocké dans la variable count
    // lorsqu'on clicque sur le bouton plus, incrémenter le compteur et remplacer la valeur actuelle du champ par celle de count
    $('#plus').click(function () {
        count++;
        $('#counter').val(count);
    });
    // lorsqu'on clique sur le bouton moins, décrémenter le compteur et remplacer la valeur actuelle du champ par celle de count
    $('#minus').click(function () {
        count--;
        $('#counter').val(count);
    });
});