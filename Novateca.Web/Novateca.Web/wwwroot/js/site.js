// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {
    $("#btnShowLoginModal").click(function () {
        $("#loginModal").modal('show');
    });

    $("#btnHideLoginModal").click(function () {
        $("#loginModal").modal('hide');
    });

    $("#btnShowRegisterModal").click(function () {
        $("#registerModal").modal('show');
    });

    $("#btnHideRegisterModal").click(function () {
        $("#registerModal").modal('hide');
    });
});

$(function () {
    $("#dialog").dialog();
});