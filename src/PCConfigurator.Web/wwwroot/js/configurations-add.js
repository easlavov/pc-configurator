$(document).ready(function () {
    var components = [];

    $.getJSON("/Components/LoadAllComponents").done(function (response) {
        components = response;
    });
});