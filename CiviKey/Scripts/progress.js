$(function () {

    $('.accordion-group').on('hide', function () {
        var elem = $('.collapse-image', this);
        elem.removeClass('expended');
        elem.addClass('colapsed');
    });

    $('.accordion-group').on('show', function () {
        var elem = $('.collapse-image', this);
        elem.removeClass('colapsed');
        elem.addClass('expended');
    });

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
            width: 623,
            height: 800,
            draggable: true,
            modal: true,
            show: 'fade',
            resizable: false,
            hide: { effect: 'fade', duration: 200 },
            close: function (e, ui) {
                $('#video iframe').attr('src', "");
            },
            dragStop: function (event, ui) {
                if ($(".feature-dialog").css("top").toString().charAt(0) === '-') {
                    $(".feature-dialog").css("top", 0);
                }
            }
        }).load("/Feature/Index/" + featureId, function () {
            $("#dialog-container").dialog('open');
            if ($(".feature-info").height() > 600) {
                $(".feature-info").height(600);
            }
        });
    });
});

