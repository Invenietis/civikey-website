$(function () {
    $(".show-more-features").click(function () {
        $(".hidden-feature").removeClass("hidden-feature");
        $(this).hide();
    })


    $(".timeline-buttons").mouseenter(function () {
        $(this).addClass("hover");
    });

    $(".timeline-buttons").mouseleave(function () {
        $(this).removeClass("hover");
    });

});

