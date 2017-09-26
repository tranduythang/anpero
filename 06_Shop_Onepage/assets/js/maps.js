 google.maps.event.addDomListener(window, 'load', init);

 function init() {
     var mapOptions = {
         zoom: 11,
         scrollwheel: false,
         mapTypeControl: false,
         zoomControl: false,
         scaleControl: false,
         streetViewControl: false,
         rotateControl: false,
         center: new google.maps.LatLng(23.810332, 90.41251809999994),
         styles:

[
             {
                 "featureType": "administrative",
                 "elementType": "labels.text.fill",
                 "stylers": [
                     {
                         "color": "#444444"
            }
        ]
    },
             {
                 "featureType": "landscape",
                 "elementType": "all",
                 "stylers": [
                     {
                         "color": "#f2f2f2"
            }
        ]
    },
             {
                 "featureType": "poi",
                 "elementType": "all",
                 "stylers": [
                     {
                         "visibility": "off"
            }
        ]
    },
             {
                 "featureType": "road",
                 "elementType": "all",
                 "stylers": [
                     {
                         "saturation": -100
            },
                     {
                         "lightness": 45
            }
        ]
    },
             {
                 "featureType": "road.highway",
                 "elementType": "all",
                 "stylers": [
                     {
                         "visibility": "simplified"
            }
        ]
    },
             {
                 "featureType": "road.highway",
                 "elementType": "geometry.fill",
                 "stylers": [
                     {
                         "saturation": "73"
            },
                     {
                         "lightness": "100"
            },
                     {
                         "visibility": "on"
            },
                     {
                         "weight": "1.31"
            }
        ]
    },
             {
                 "featureType": "road.highway",
                 "elementType": "geometry.stroke",
                 "stylers": [
                     {
                         "saturation": "-35"
            },
                     {
                         "lightness": "66"
            },
                     {
                         "gamma": "3.97"
            }
        ]
    },
             {
                 "featureType": "road.arterial",
                 "elementType": "labels.icon",
                 "stylers": [
                     {
                         "visibility": "off"
            }
        ]
    },
             {
                 "featureType": "transit",
                 "elementType": "all",
                 "stylers": [
                     {
                         "visibility": "off"
            }
        ]
    },
             {
                 "featureType": "water",
                 "elementType": "all",
                 "stylers": [
                     {
                         "color": "#add35d"
            },
                     {
                         "visibility": "on"
            }
        ]
    }
]
     };
     var mapElement = document.getElementById('maps');
     var map = new google.maps.Map(mapElement, mapOptions);
     var marker = new google.maps.Marker({
         position: new google.maps.LatLng(23.810332, 90.41251809999994),
         map: map,
         icon: 'images/map-marker.png'
     });
 }