$(function () {
    document.CK = {};
    document.CK.AjaxCallbacks = {
        onProgressGetFeatureViewSuccess: function () {
            var roadmapId = $(".progress-list-of-features")[0].getAttribute("data-id");
            $(".timeline-feature-link").removeClass("timeline-selected");
            $(".timeline-feature-link.roadmap-" + roadmapId).addClass("timeline-selected");
        },
        onProgressCategoryChangeSuccess: function () {
            $(".timeline-feature-link").each(function (index, el) {
                el.href
                if (el.href.indexOf("classic") != -1) {
                    var newHref = el.href.replace("classic", "categorized");
                    el.href = newHref;
                }
                else if (el.href.indexOf("categorized") != -1) {
                    var newHref = el.href.replace("categorized", "classic");
                    el.href = newHref;
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
        moElem.css('display', 'block');
    }
    else moElem.css('display', 'none');

    $('.menuelem').mouseover(function () {
        var left = $(this).position().left;
        var width = $(this).width() + 40;

        moElem.css('width', width);
        moElem.css('left', left);
        moElem.css('display', 'block');

    });

    $('.header-menu-container').mouseleave(function () {
        if (selectedItem.length == 0) {
            moElem.css('display', 'none');
        } else {
            var left = selectedItem.position().left;
            var width = selectedItem.width() + 40;

            moElem.css('width', width);
            moElem.css('left', left);
            moElem.css('display', 'block');
        }
    });
});