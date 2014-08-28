    $(document).ready(function () {

        var currentDate = $('[id*=dateLabel]').text();
        if (currentDate != "") {
            $('.datepicker').datepicker({
                todayBtn: "linked",
                startDate: '+0d'
            }).datepicker('update', currentDate).on("changeDate", function (e) {
                $("#EstimatedDispatchDate").val(e.format(0, "yyyy-mm-dd"));
            });
        }

        else {
            $('.datepicker').datepicker({
                todayBtn: "linked",
                startDate: '+0d'
            }).on("changeDate", function (e) {
                $("#EstimatedDispatchDate").val(e.format(0, "yyyy-mm-dd"));
            });
            $("#EstimatedDispatchDate").val(null);
        }

    });