$(document).ready(function(){
    console.log("JS is connected.");

    $("#map").ready(function(){
        console.log("Ready");
    });
});

function initMap() {
    //Get data from API (APIs URL)
    //Fake API for testing purposes
    //JSON content of the response: {"a":{"id":"TG_001", "lat":46.22306, "lon":16.12}, "b":{"id":"TG_002", "lat":46.30444, "lon":16.33778}, "c":{"id":"TG_003", "lat":46.24306, "lon":16.20}}
    var URL = "https://mocki.io/v1/015b79a6-dc0a-4e88-8318-5f64682d1ccd";
    $.ajax({type: "GET", url: URL, dataType: "json", complete: function(data){
        var gates = $.parseJSON(data.responseText);
        
        const fistGate = { lat: gates["a"].lat, lng: gates["a"].lon };
        
        const map = new google.maps.Map(document.getElementById("map"), {
        zoom: 11,
        center: fistGate,
        });

        for(g in gates){
            const location = {lat: gates[g].lat, lng: gates[g].lon};
            setMarker(location, map, gates[g].id);
        }

    }});
    
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