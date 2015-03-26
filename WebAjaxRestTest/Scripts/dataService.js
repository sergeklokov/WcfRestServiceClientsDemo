/// <reference path="//ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js" />

var urlBase = "http://localhost:5576/PunService.svc/Puns";

var dataService = function () {
        getCustomers = function() {
            return "customers";
        },

        getPunsData = function() {
            return $.getJSON(urlBase);
        },

        getPuns = function() {
            //return "puns";
            var promise = getPunsData();

            promise.done(function(puns) {
                    var punsHtml = "";
                    for (var i = 0; i < puns.length; i++) {
                        punsHtml += "<li>" + puns[i].Title + "</li>";
                    };

                    $("#GetPuns").html(punsHtml);
                })
                .fail(function(jqXHR, textStatus, errorThrown) {
                    alert('getJSON request failed! ' + textStatus);
                });

        };

    return {
        getCustomers: getCustomers,
        getPuns: getPuns
    };
}();