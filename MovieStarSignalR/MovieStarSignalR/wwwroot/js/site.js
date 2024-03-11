"use strict"
var connection = new signalR.HubConnectionBuilder()
    .withUrl("/SignalRServer")
    .build();

connection.on("LoadMovies", function () {
    location.href = '/List'
})
connection.start().catch(function (err) {
    return console.error(err.toString());
});

