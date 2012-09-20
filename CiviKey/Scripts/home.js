$(function () {
    setInterval(function () {
        getTestimony();
    }, 10000);

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


    var selectedSlideId;
    var slideHeight;
    $('.slider-menu-elem').click(function () {
        if (!$(this).hasClass('selected')) {
            $('.slider-menu-elem').removeClass('selected');
            $(this).addClass('selected');
            slideHeight = $('.slider-image').height();
            selectedSlideId = $(this).data('id');
            $('.home-slider-left-container').css('top', -slideHeight * selectedSlideId);
        }
    });
});

