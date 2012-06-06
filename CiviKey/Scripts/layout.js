$(function () {
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