$(function () {
    setInterval(function () {
        getTestimony();
    }, 20000);

    var getTestimony = function () {
        $.ajax({
            url: 'Home/GetTestimonyView',
            data: { currentTestimonyId: $("#testimony-title").attr("data-id") },
            success: function (data) {
                if ($("#testimony-title").attr("data-id") == undefined) {
                    $("#testimony-container").html(data);
                }
                else {
                    if ($($(data)[0]).attr("data-id") !== $("#testimony-title").attr("data-id")) {
                        $("#testimony-container").fadeOut(1000, function () {
                            $(this).html(data).fadeIn();
                        });
                    }
                }
            }
        });
    }
    getTestimony();

    $('.carousel').carousel({
        interval: 2000
    })
    $('.carousel').carousel('pause');
});

