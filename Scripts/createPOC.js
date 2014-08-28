
    $(document).ready(function () {
        $('.datepicker').datepicker({
            todayBtn: "linked",
            startDate: '+0d'
        }).on("changeDate", function (e) {
            $("#EstimatedDispatchDate").val(e.format(0, "yyyy-mm-dd"));
        });

        $("#EstimatedDispatchDate").val(null);

    });