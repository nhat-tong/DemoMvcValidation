// setup bootstrap v3 datepicker for all DOM elements
// which are datepicker controls

$(function () {
    $('.datepicker').each(function (index) {
        var $this = $(this);

        // init datepicker with format FR
        $this.datetimepicker({
            format: 'DD/MM/YYYY'
        });
    });
});