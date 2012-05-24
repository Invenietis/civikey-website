$(function () {
    var actionTerminated=true;

    $('.project-menuelem.leprojet').click(function () {
        if (changeActiveElem("leprojet") && actionTerminated) {
            actionTerminated = false;
            $('.project-slide2').fadeOut(function () {
                $('.project-slide3').fadeOut(function () {
                    $('.project-slide1').fadeIn(function () {
                        actionTerminated = true;
                    });
                });
            });
        }
    });

    $('.project-menuelem.aide').click(function () {
        if (changeActiveElem("aide") && actionTerminated) {
            actionTerminated = false;
            $('.project-slide1').fadeOut(function () {
                $('.project-slide3').fadeOut(function () {
                    $('.project-slide2').fadeIn(function () {
                        actionTerminated = true;
                    });
                });
            });
        }
    });

    $('.project-menuelem.acteurs').click(function () {
        if (changeActiveElem("acteurs") && actionTerminated) {
            actionTerminated = false;
            $('.project-slide2').fadeOut(function () {
                $('.project-slide1').fadeOut(function () {
                    $('.project-slide3').fadeIn(function () {
                        actionTerminated = true;
                    });
                });
            });
        }
    })

    function changeActiveElem(clickedElem) {
        var thisElem = $('.project-menuelem.' + clickedElem);

        if (!thisElem.hasClass('active')&& actionTerminated) {
            $('.project-menuelem').removeClass('active');
            $('.project-menuelem').addClass('inactive');
            thisElem.removeClass('inactive');
            thisElem.addClass('active');
            return true;
        } else {
            return false;
        }
    }


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