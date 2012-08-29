$(function () {
    document.CK = {};
    document.CK.AjaxCallbacks = {
        onProgressGetFeatureViewSuccess: function () {
            var roadmapId = $(".progress-list-of-features")[0].getAttribute("data-id");
            $(".timeline-feature-link").removeClass("timeline-selected");
            $(".timeline-feature-link.roadmap-" + roadmapId).addClass("timeline-selected");
        },
        onProgressCategoryChangeSuccess: function (type) {
            $(".timeline-feature-link").each(function (index, el) {
                if (type == 'classic') {
                    el.href = el.href.replace("categorized", "classic");
                }
                else if (type == 'categorized') {
                    el.href = el.href.replace("classic", "categorized");
                }
            });
        }
    };

    var menuItems = 4;

    var moElem = $('.moving-elem');
    var selectedItem = $('.menuelem.selected');
    if (selectedItem.length > 0) {
        var left = selectedItem.position().left;
        var width = selectedItem.width() + 40;

        moElem.css('width', width);
        moElem.css('left', left);
        moElem.css('opacity', '1');
        //moElem.css('display', 'block');
    }
    else {
        moElem.css('opacity', '0');
        //moElem.css('display', 'none');
    }

    $('.menuelem').mouseover(function () {
        var left = $(this).position().left;
        var width = $(this).width() + 40;
        moElem.css('width', width);
        moElem.css('left', left);
        moElem.css('opacity', '1');

        //moElem.css('display', 'block');

    });
    $('#menu').mouseover(function () {
        if ($('.moving-elem').css('opacity') != 0) {
            moElem.addClass('moving-elem-all');
        } else {
            moElem.removeClass('moving-elem-all');
        }
    });

    $('.header-menu-container').mouseleave(function () {
        if (selectedItem.length<0.2) {
            moElem.css('opacity', '0');
            //moElem.css('display', 'none');
        } else {
            var left = selectedItem.position().left;
            var width = selectedItem.width() + 40;

            moElem.css('width', width);
            moElem.css('left', left);
            moElem.css('opacity', '1');
            //moElem.css('display', 'block');
        }
    });
});