/// <reference path="jquery-1.6.2-vsdoc.js" />
/// <reference path="google-maps-3-vs-1-0-vsdoc.js" />

function GMap () {
    var map;
    var markers = [];
    
    /// initializes a new instance of the GMap class.
    GMap.prototype.initialize = function (mapContainerElement, latitude, longitude) {
        var latlng = new google.maps.LatLng(latitude, longitude);
        var myOptions = {
            zoom: 6,
            center: latlng,
            mapTypeId: google.maps.MapTypeId.ROADMAP
        };
        map = new google.maps.Map(mapContainerElement, myOptions);
    }

    /// place marker on specified localization and title.
    GMap.prototype.placeMarker = function (latitude, longitude, title) {
        marker = new google.maps.Marker({
            position: new google.maps.LatLng(latitude, longitude),
            map: map,
            title: title
        });

        markers.push(marker);
    }

    /// remove all markers from map.
    GMap.prototype.clearMarkers = function () {
    	for (i in markers) {
            markers[i].setMap(null);
        }
        markers.length = 0;
    }
}
