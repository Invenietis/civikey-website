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
            autoOpen: false,
            width: 622,
            draggable: true,
            modal: true,
            show: 'fade',
            resizable: false,
            hide: { effect: 'fade', duration: 200 },
            close: function (e, ui) {
                $('#video iframe').attr('src', "");
            },
            open: function () {
//                $(".feature-dialog").css("top", $("#header").css("height"));
//                $(".feature-dialog").css("left", $("body").width() - $(".feature-dialog").width() - 10);
            },
            dragStop: function (event, ui) {
                if ($(".feature-dialog").css("top").toString().charAt(0) === '-') {
                    $(".feature-dialog").css("top", 0);
                }
            }
        }).load("/Feature/Index/" + featureId, function () {
            $("#dialog-container").dialog('open');
        });
    });
});

