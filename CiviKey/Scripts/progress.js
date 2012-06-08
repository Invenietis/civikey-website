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


    $(".progress-list-elem").live("click", function () {
        var featureId = this.getAttribute("data-id");
        $("#dialog-container").dialog({
            dialogClass: 'feature-dialog',
            autoOpen: true,
            height: 620,
            width: 620,
            draggable: false,
            modal: true,
            show: 'fade',
            resizable: false,
            hide: { effect: 'fade', duration: 200 },
            close: function (e, ui) { $('#video iframe').attr('src', ""); }
        }).load("/Feature/Index/" + featureId);
    });
});

