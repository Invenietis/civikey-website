﻿/*
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

document.CK = {
    setSponsorHtml: function (param, options) {
        var fontSize = 15;
        var parentDivHeight = options.height + fontSize * 2;
        var parentDivWidth = options.width;
        var newWidth;
        var totalPercentage = 0;
        var colors = new Array('#4b4b4b', '#7bb2e8', '#ffb10a', '#78ff0a', '#ff00ea');

        for (var i = 0; i < param.length; i++) {
            totalPercentage = totalPercentage + param[i].Percentage;
        }

        $(options.parent).html('<div class="jsponsor-container" style="width:' + parentDivWidth + 'px; font-family:Verdana; font-size:' + fontSize + 'px;" ><div class="jsponsor-first-lvl" style="margin-bottom:5px; width:' + parentDivWidth + 'px; height:' + fontSize + 'px;"></div><div class="jsponsor-bar" style="width:' + parentDivWidth + 'px; height:' + options.height + 'px;"></div><div class="jsponsor-second-lvl" style="margin-top:5px; width:' + parentDivWidth + 'px; height:' + fontSize + 'px;"></div>');

        for (var i = 0; i < param.length; i++) {
            newWidth = (options.width * (param[i].Percentage / totalPercentage * 100)) / 100;
            if (i % 2 == 0) {
                $('.jsponsor-first-lvl').append('<div style="float:left; width:' + newWidth + 'px; color:' + colors[i] + '"; ">' + param[i].Name + " " + param[i].Percentage / totalPercentage * 100 + "%" + '</div>');
                $('.jsponsor-bar').append('<div style="float:left; width:' + newWidth + 'px; height:' + options.height + 'px; background-color:' + colors[i] + '"></div>');
                $('.jsponsor-second-lvl').append('<div style="float:left; width:' + newWidth + 'px; height:' + fontSize + 'px;"></div>');
            } else {
                $('.jsponsor-first-lvl').append('<div style="float:left; width:' + newWidth + 'px; height:' + fontSize + 'px;"></div>');
                $('.jsponsor-bar').append('<div style="float:left; width:' + newWidth + 'px; height:' + options.height + 'px; background-color:' + colors[i] + '"></div>');
                $('.jsponsor-second-lvl').append('<div style="float:left; width:' + newWidth + 'px; color:' + colors[i] + '">' + param[i].Name + " " + param[i].Percentage / totalPercentage * 100 + "%" + '</div>');
            }
        }

        $('.jsponsor-first-lvl').append('<div style="clear:both;"></div>');
        $('.jsponsor-bar').append('<div style="clear:both;"></div>');
        $('.jsponsor-second-lvl').append('<div style="clear:both;"></div>');
    },

    setVideoSlider: function (video) {
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

        $('.close').click(function () {
            $('.feature-demo').css('border-color', '#fff');
            $('#video video')[0].pause();
            selectedElem = -1;
            $('#video').slideUp();

        });
    }

}