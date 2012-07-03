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
    document.CK.setSponsorHtml = function (param, options) {
        var fontSize = 15;
        var parentDivHeight = options.height + fontSize * 2;
        var parentDivWidth = options.width;
        var newWidth;
        var totalPercentage = 0;
        var colors = new Array('#4b4b4b', '#7bb2e8', '#ffb10a', '#88ff0a', '#ff00ea');

        for (var i = 0; i < param.length; i++) {
            totalPercentage = totalPercentage + param[i].Percentage;
        }

        $(options.parent).html('<div class="jsponsor-container" style="width:' + parentDivWidth + 'px; font-family:Verdana; font-size:' + fontSize + 'px;" ><div class="jsponsor-first-lvl" style=" width:' + parentDivWidth + 'px; height:' + fontSize + 'px;"></div><div class="jsponsor-bar" style="width:' + parentDivWidth + 'px; height:' + options.height + 'px;"></div><div class="jsponsor-second-lvl" style="margin-top:5px; width:' + parentDivWidth + 'px; height:' + fontSize + 'px;"></div>');

        for (var i = 0; i < param.length; i++) {
            newWidth = (options.width * (param[i].Percentage / totalPercentage * 100)) / 100;
            if (i % 2 == 0) {
                $('.jsponsor-first-lvl').append('<div style="float:left; width:' + newWidth + 'px; color:' + colors[i] + ';" >' + param[i].Name + '</div>');
                $('.jsponsor-bar').append('<div style="float:left; width:' + newWidth + 'px; height:' + options.height + 'px; background-color:' + colors[i] + '"></div>');
                $('.jsponsor-second-lvl').append('<div style="float:left; width:' + newWidth + 'px; color:' + colors[i] + '"><span class="sponsor-percent">' + ((param[i].Percentage / totalPercentage * 100) | 0) + '%</span></div>');
            } else {
                $('.jsponsor-first-lvl').append('<div style="float:left; width:' + newWidth + 'px; color:' + colors[i] + '"> <span class="sponsor-percent">' + ((param[i].Percentage / totalPercentage * 100) | 0) + '%</span></div>');
                $('.jsponsor-bar').append('<div style="float:left; width:' + newWidth + 'px; height:' + options.height + 'px; background-color:' + colors[i] + '"></div>');
                $('.jsponsor-second-lvl').append('<div style="float:left; width:' + newWidth + 'px; color:' + colors[i] + '">' + param[i].Name + '</div>');
            }
        }

        $('.jsponsor-first-lvl').append('<div style="clear:both;"></div>');
        $('.jsponsor-bar').append('<div style="clear:both;"></div>');
        $('.jsponsor-second-lvl').append('<div style="clear:both;"></div>');
    }
});