$(document).ready(function () {
    $.getJSON("/Components/LoadAllComponents").done(function (response) {
        console.log(response)
    });
});