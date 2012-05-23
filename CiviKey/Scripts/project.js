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
});