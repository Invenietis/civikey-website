/*
setSponosorHtml 
var param = {{Name:'Company1', Percentage:30%},{Name:'Company2', Percentage:70%}};
var options = {
width:520,
height:4,
parent: ".js-sponsor"
}

where:
PARENT is the class of the <div> where you want that the plugin generate the HTML statistic block
HEIGHT is the progress bar's height
WIDTH is the container's width

setSponsorHtml(param,options); //and thats ALL :)

*/
$(function () {
    document.CK.setVideoSlider = function (video) {
        var selectedElem = -1;

        $('.feature-demo').click(function () {
            elemId = $(this).attr('id').charAt(1);
            if (selectedElem == -1) {
                $('.feature-demo').css('border-color', '#fff');
                $('#video source').attr('src', '/Content/video/' + video[elemId].VideoSource);
                $(this).css('border-color', '#509BE4');
                $('#video').slideDown(function () {
                    $('.feature-info').animate({ scrollTop: ($('.content-before-video').height() + $('.feature-demo').height() + 75) }, 'fast');
                });
                selectedElem = elemId;
                $('#video video')[0].load();
                $('#video video')[0].play();
            } else if (elemId != selectedElem) {
                $('.feature-demo').css('border-color', '#fff');
                $(this).css('border-color', '#509BE4');
                $('#video video')[0].pause();
                $('#video source').attr('src', '/Content/video/' + video[elemId].VideoSource);
                $('.feature-info').animate({ scrollTop: ($('.content-before-video').height() + $('.feature-demo').height() + 75) }, 'fast');
                $('#video video')[0].load();
                $('#video video')[0].play();
                selectedElem = elemId;
            }
        });

        $('.close').live('click', function () {
            $('.feature-demo').css('border-color', '#fff');
            $('#video video')[0].pause();
            selectedElem = -1;
            $('#video').slideUp();

        });
    }

    
});
