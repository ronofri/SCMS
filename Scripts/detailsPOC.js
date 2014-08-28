$(document).ready(function () {
    var currentDate = $('[id*=dateLabel]').text();
    if (currentDate != "") {
        $('.datepicker').datepicker({ format: "MM-dd-yyyy" })
        .datepicker('setStartDate', currentDate)
        .datepicker('setEndDate', currentDate)
        .datepicker('update', currentDate);
        $('td.day.active').addClass('disabled');
        $('th.datepicker-switch').addClass('disabled');
    }
    else {
        $('.datepicker').datepicker({ format: "MM-dd-yyyy" })
        .datepicker('setStartDate', '+1d')
        .datepicker('setEndDate', '-1d');
        $('td.day.active').addClass('disabled');
        $('th.datepicker-switch').addClass('disabled');
    }
});