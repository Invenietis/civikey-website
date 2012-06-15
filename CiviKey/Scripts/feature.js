$(function () {
    document.CK.setVideoSlider = function (video) {
        var selectedElem = -1;

        $('.feature-demo').click(function () {
            elemId = $(this).attr('id').charAt(1);
            if (selectedElem == -1) {
                $('.feature-demo').css('border-color', '#fff');
                $('#video iframe').attr('src', 'http://www.youtube.com/embed/' + video[elemId].VideoSource);
                $(this).css('border-color', '#509BE4');
                $('#video').slideDown(function () {
                    $('.feature-info').animate({ scrollTop: ($('.content-before-video').height() + $('.feature-demo').height() +87) }, 'fast');
                });
                selectedElem = elemId;
            } else if (elemId != selectedElem) {
                $('.feature-demo').css('border-color', '#fff');
                $(this).css('border-color', '#509BE4');
                $('#video iframe').attr('src', 'http://www.youtube.com/embed/' + video[elemId].VideoSource);
                $('.feature-info').animate({ scrollTop: ($('.content-before-video').height() + $('.feature-demo').height() + 87) }, 'fast');
                selectedElem = elemId;
            }
        });

        $('.close').live('click', function () {
            $('.feature-demo').css('border-color', '#fff');
            $('#video iframe').attr('src', '');
            selectedElem = -1;
            $('#video').slideUp();

        });
    }

    
});
