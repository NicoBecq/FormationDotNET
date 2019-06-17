$(document).ready(function () {
    $(function () {
        $('#datetimepicker1').datetimepicker({
            locale: 'fr',
            minDate: new Date(),
            daysOfWeekDisabled: [0, 6],
            stepping: 30,
            icons: {
                time: "far fa-clock",
                date: "fa fa-calendar",
                up: "fa fa-arrow-up",
                down: "fa fa-arrow-down"
            }
        });
    });
    // override la validation.unobstrusive
    $(function () {
        $.validator.methods.date = function (value, element) {
            Globalize.culture("fr");
            return this.optional(element) || Globalize.parseDate(value) !== null;
        }
    });
    $("#delete_submit").click(function (event) {
        var anwser = confirm("Voulez vous vraiment supprimer?\nCette opération est définitive");
        if (!anwser) {
            event.preventDefault();
        }
    });
});