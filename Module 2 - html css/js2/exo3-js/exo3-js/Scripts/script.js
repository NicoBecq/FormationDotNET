var nameField = document.querySelector('#lastname'); // stockage de la balise contenant l'id lastname
// appel d'une fonction sur l'evenement keyup
nameField.addEventListener('keyup', function () {
    window.alert(this.value);
});