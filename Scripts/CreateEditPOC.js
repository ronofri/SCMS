$(document).ready(function () {
    $('#CustomerProperty').typeahead(
        {
            source: function (query, process) {
                var customers = [];
                map = {};

                // This is going to make an HTTP post request to the controller
                return $.post('/POC/CustomerSearch', { query: query }, function (data) {
                    // Loop through and push to the array
                    //alert($('#CustomerProperty').val());

                    $.each(data, function (i, customer) {

                        var property = customer.CustomerProperty;
                        map[property] = customer;
                        customers.push(property);
                    });


                    // Process the details
                    process(customers);
                });
            }
        });
    $('#DestinationPort').typeahead(
        {
            source: function (query, process) {
                var ports = [];
                map = {};

                // This is going to make an HTTP post request to the controller
                return $.post('/POC/PortSearch', { query: query }, function (data) {
                    // Loop through and push to the array
                    //alert(data);

                    $.each(data, function (i, port) {

                        var property = port.PortProperty;
                        map[property] = port;
                        ports.push(property);
                    });


                    // Process the details
                    process(ports);
                });
            }
        });
});

$(document).ready(function () {
    $('#sendButton').on("click", function () {
        $('[id*=error_]').addClass('hidden');
        if ($('#labelDestinationError').length) {
            $('#labelDestinationError').text("");
        }
        if ($('#labelPortError').length) {
            $('#labelPortError').text("");
        }
        var sendPost = true;
        //Missing some error on double conditions.
        if ($('#CustomerProperty').val() == "") {
            $('#error_destination').text("Destination value is Required");
            $('#error_destination').removeClass('hidden');
            sendPost = false;
        }
        if ($('#DestinationPort').val() == "") {
            $('#error_port').text("Destination value is Required");
            $('#error_port').removeClass('hidden');
            sendPost = false;
        }
        if ($('#SelectedIncotermId option:selected').val() == "") {
            $('#error_incoterm').text("Incoterm value is Required");
            $('#error_incoterm').removeClass('hidden');
            sendPost = false;
        }

        if ($('#SelectedBallId option:selected').val() == "") {
            $('#error_ball').text("Ball Type value is Required");
            $('#error_ball').removeClass('hidden');
            sendPost = false;
        }
        var tons = $('#Tons').val();

        if (!(Math.floor(tons) == tons && $.isNumeric(tons) && tons > 0)) {
            $('#error_tons').text("The Amount of Tons Should Be a Number");
            $('#error_tons').removeClass('hidden');
            sendPost = false;
        }

        var price = $('#PricePerTon').val();

        if (!($.isNumeric(price) && price > 0)) {
            $('#error_price').text("The Price per Ton Should Be a Number");
            $('#error_price').removeClass('hidden');
            sendPost = false;
        }

        if ($("#EstimatedDispatchDate").val() == "") {
            $('#error_date').text("Estimated Dispatch Date is Required");
            $('#error_date').removeClass('hidden');
            sendPost = false;
        }
        return sendPost;
    });
});

$(document).ready(function () {
    $("input:text").on("click", function () {
        $(this).select();
    });
});