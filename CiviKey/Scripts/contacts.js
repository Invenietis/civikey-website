$(function () {
    var myLatlng = new google.maps.LatLng(48.857473, 2.384012);
    var infowindow = new google.maps.InfoWindow({
        content: "Invenietis</br>10 rue Mercoeur</br>75011"
    });

    var myOptions = {
        center: new google.maps.LatLng(48.857473, 2.384012),
        zoom: 15,
        mapTypeControl: false,
        mapTypeId: google.maps.MapTypeId.ROADMAP
    };

    var map = new google.maps.Map(document.getElementById("map_canvas"), myOptions);

    var marker = new google.maps.Marker({
        position: myLatlng,
        title: 'Invenietis',
        zoomControl: true,
        map: map
    });

    google.maps.event.addListener(marker, 'click', (function (marker) {
        return function () {
            infowindow.open(map, marker);
        }
    })(marker));

    
});