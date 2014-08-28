$('#inputDestination').on('keyup', function () {
    var texto = $(this).val();

    $('#tableDestinationAutocomplete td.dropdown').each(function () {
        var td = $(this);
        var tdTexto = td.text();
        //alert(tdTexto);
        if (tdTexto.toLowerCase().indexOf(texto) > 0) {
            td.removeClass('hidden');
        }
        else {
            td.addClass('hidden');
        }
    });

    $('#tableDestinationAutocomplete td.dropdown').on('click', function (e) { alert($(this).text()); e.stopImmediatePropagation(); });
});