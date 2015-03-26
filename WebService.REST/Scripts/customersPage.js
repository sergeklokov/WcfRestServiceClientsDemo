/// <reference path="//ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js" />
var customersPage = function() {
    var urlBase = "http://localhost:5576/PunService.svc/Puns",
        init = function () {

            $("#GetCustomers").click(function() {
                alert("blah");

                //$.getJSON(urlBase, function(custs) {
                //    var custsHtml = "";
                //    for (var i = 0; i < custs.length; i++) {
                //        custsHtml += "<li>" + custs[i].Title + "</li>";
                //    }
                //    $("#CustomersContainer").html(custsHtml);
            });

            $("#GetCustomer").click(function () {
                alert("customer");
            });

        }
};

$(document).on("click", "#members li a", function (e) {
    e.preventDefault();
    var s = dataService.getCustomers(); //calling to our "objects
    toastr.success($(this).text(), "Click " + s);
});

$(document).on("click", "#GetPuns", function (e) {
    //e.preventDefault();
    var s = dataService.getPuns(); //calling to our "patterns"
    toastr.success($(this).text(), "Click " + s);
});


$("button").on("click", function () {
    $("<li><a href='detail.html?id=6'>Detail 6</a></li>").appendTo("#members");
});