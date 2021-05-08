$(document).ready(function () {
    GetShowData();
});

function GetShowData() {
    $.getJSON('api/Orders')
        .done(function (data) {
            $.each(data, function (key, item) {
                $('<option>', { text: item }).appendTo($('#employee'))
            })
        })
        .fail(function (data) {
            console.log("Error getting employees");
        });

    $.getJSON('api/Stores')
        .done(function (data) {
            $.each(data, function (key, item) {
                $('<option>', { text: item }).appendTo($('#city'))
            })
        })
        .fail(function (data) {
            console.log("Error getting city");
        });
}

function getMarkUps() {
    $("#listUl").empty();
    $.getJSON('api/MarkUps')
        .done(function (data) {
            //console.log(data);
            $.each(data, function (key, item) {
                //console.log(item);
                $('<li>', { text: "City: " + item.City + ", Count: " + item.Count }).appendTo($('#listUl'))
            })
        })
        .fail(function (data) {
            console.log("Error getting markups");
        });
}

function getEmployee() {
    $("#employeeSales").empty();
    var fullName = $("#employee").children("option:selected").val();
    var lastName = fullName.split(' ').slice(-1).join(' ');
    //console.log(fullName, lasName);
    $.getJSON('api/Orders' + '/' + lastName)
        .done(function (data) {
            console.log(data);
            $('<span>', { text: "This employee sold $" + data + " for the year" }).appendTo($('#employeeSales'))
        });
}

function getStore() {
    $("#storeSales").empty();
    var store = $("#city").children("option:selected").val();
    //console.log(store);
    $.getJSON('api/Stores' + '/' + store)
        .done(function (data) {
            console.log(data);
            $('<span>', { text: "This store sold $" + data + " for the year" }).appendTo($('#storeSales'))
        });
}