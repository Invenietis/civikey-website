$(function () {
    var History = window.History;
    var closing = false;
    History.Adapter.bind(window, 'statechange', function () {
        var State = History.getState();
        var state = null;
        if (State.data.type == 'feature') {

            $("#dialog-container").dialog({
                dialogClass: 'feature-dialog',
                autoOpen: false,
                width: 623,
                draggable: true,
                modal: true,
                show: 'fade',
                resizable: false,
                hide: { effect: 'fade', duration: 200 },
                beforeClose: function (event, ui) {
                    if (!closing) {
                        state = {
                            type: 'close'
                        };
                        History.pushState(state, '', Civi.getFeatureUrl());
                        return false;
                    }
                },
                close: function (e, ui) {
                    closing = false;
                    $('#video iframe').attr('src', "");
                },
                dragStop: function (event, ui) {
                    if ($(".feature-dialog").css("top").toString().charAt(0) === '-') {
                        $(".feature-dialog").css("top", 0);
                    }
                }
            }).load(State.data.route, function () {
                $("#dialog-container").dialog('open');
                FB.XFBML.parse();
                twttr.widgets.load();
            });

        } else {
            closing = true;
            $("#dialog-container").dialog('close');
        }
    });


    $(function () {
        $('.accordion-group').live('hide', function () {
            var elem = $('.collapse-image', this);
            elem.removeClass('expended');
            elem.addClass('colapsed');
        });

        $('.accordion-group').live('show', function () {
            var elem = $('.collapse-image', this);
            elem.removeClass('colapsed');
            elem.addClass('expended');
        });


        $(".timeline-buttons").mouseenter(function () {
            $(this).addClass("hover");
        });

        $(".timeline-buttons").mouseleave(function () {
            $(this).removeClass("hover");
        });

        $(".collapse-image").live("click", function () {
            var targetId = $(".accordion-toggle", $(this).parent()).attr("href");
            $(targetId).collapse("toggle");
        });

        $(".category-img").live("click", function () {
            var targetId = $(".accordion-toggle", $(this).parent()).attr("href");
            $(targetId).collapse("toggle");
        });

        $(".progress-list-elem").live("click", function () {
            var state = {
                type: 'feature',
                route: this.getAttribute("data-requestroute")
            };
            History.pushState(state, this.getAttribute('data-title'), Civi.getFeatureUrl(this.getAttribute('data-title')));
        });
    });
});

