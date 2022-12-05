$(document).ready(function(){
    console.log("JS is connected.");

    $("#map").ready(function(){
        console.log("Ready");
    });
    
});

function initMap() {
    var gates = getGates();
    const fistGate = { lat: gates["0"].lat, lng: gates["0"].lon };
    
    const map = new google.maps.Map(document.getElementById("map"), {
      zoom: 11,
      center: fistGate,
    });

    for(g in gates){
        const location = {lat: gates[g].lat, lng: gates[g].lon};
        setMarker(location, map, gates[g].id);
    }
}

function setMarker(location, map, gateID){
    var infowindow = new google.maps.InfoWindow({
        content: "<span>"+gateID+"</span>"
    });

    const marker = new google.maps.Marker({
        position: location,
        map: map,
    });

    marker.addListener("click", () => {
        infowindow.open(map, marker);
    });
}

//change this to get data from API
function getGates(){
    return {
        "0":{"id":"TG_001", "lat":46.22306, "lon":16.12},
        "1":{"id":"TG_002", "lat":46.30444, "lon":16.33778},
        "2":{"id":"TG_003", "lat":46.24306, "lon":16.20}
      };
}