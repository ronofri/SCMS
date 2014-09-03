$(document).ready(function () {
    $('.typeaheadCustomer').typeahead(
        {
            source: function (query, process) {
                var customers = [];
                map = {};

                // This is going to make an HTTP post request to the controller
                return $.post('/GM_POC/CustomerSearch', { query: query }, function (data) {
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
    $('.typeaheadPort').typeahead(
        {
            source: function (query, process) {
                var ports = [];
                map = {};

                // This is going to make an HTTP post request to the controller
                return $.post('/GM_POC/PortSearch', { query: query }, function (data) {
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

        var sendPost = true;
        //Missing some error on double conditions.
        if ($('#CustomerProperty').val() == "") {
            $('#error_destination').text("Customer value is Required");
            $('#error_destination').removeClass('hidden');
            sendPost = false;
        }
        if ($('#PortProperty').val() == "") {
            $('#error_port').text("Destination Port value is Required");
            $('#error_port').removeClass('hidden');
            sendPost = false;
        }
        if ($('#SelectedIncotermId option:selected').val() == "") {
            $('#error_incoterm').text("Incoterm value is Required");
            $('#error_incoterm').removeClass('hidden');
            sendPost = false;
        }

        if ($('#SelectedProductId option:selected').val() == "") {
            $('#error_ball').text("Product Type value is Required");
            $('#error_ball').removeClass('hidden');
            sendPost = false;
        }
        var tons = $('#POC_AmountTotal').val();

        if (!(Math.floor(tons) == tons && $.isNumeric(tons) && tons > 0)) {
            $('#error_tons').text("The Amount of Tons Should Be a Number");
            $('#error_tons').removeClass('hidden');
            sendPost = false;
        }

        var price = $('#POC_PricePerTon').val();

        if (!($.isNumeric(price) && price > 0)) {
            $('#error_price').text("The Price per Ton Should Be a Number");
            $('#error_price').removeClass('hidden');
            sendPost = false;
        }

        return sendPost;
    });
});

$(document).ready(function () {
    $('#saveButton').on("click", function () {
        $('[id*=error_]').addClass('hidden');

        var sendPost = true;
        //Missing some error on double conditions.
        if ($('#CustomerProperty').val() == "") {
            $('#error_destination').text("Customer value is Required");
            $('#error_destination').removeClass('hidden');
            sendPost = false;
        }

        var tons = $('#POC_AmountTotal').val();
        if (tons == "")
            tons = 0;

        if (!(Math.floor(tons) == tons && $.isNumeric(tons) && tons >= 0)) {
            $('#error_tons').text("The Amount of Tons Should Be a Number");
            $('#error_tons').removeClass('hidden');
            sendPost = false;
        }

        var price = $('#POC_PricePerTon').val();
        if (price == "")
            price = 0;

        if (!($.isNumeric(price) && price >= 0)) {
            $('#error_price').text("The Price per Ton Should Be a Number");
            $('#error_price').removeClass('hidden');
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