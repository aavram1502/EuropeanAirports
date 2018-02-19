$(function () {
    var countriesDropDown = $("#countries");
    var iso = "";

    populateCountries();

    $("#applyCountryFilter").click(function () {
        iso = countriesDropDown.val();
        $.get(`/home/index/?iso=${iso}`).done(function (data) {
            $("#content").html(data);
        });
    });

    $("#getDistance").click(function () {
        var iata1 = $("#iata1").val();
        var iata2 = $("#iata2").val();
        $.get(`/distance/index/?iata1=${iata1}&iata2=${iata2}`).done(function (data) {
            $("#content").html(data);
        });
    });

    function populateCountries() {
        $.get("/home/GetAllCountries").done(function (items) {
            append(countriesDropDown, "", "Select Country");
            $.each(items,
                function (i, item) {
                    append(countriesDropDown, item, item);
                });
        });
    }

    function append(dropdown, item, text) {
        dropdown.append($("<option>",
            {
                value: item,
                text: text
            }));
    }
});
