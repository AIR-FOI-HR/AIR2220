$(document).ready(function(){
    console.log("JS is connected.");
    $("#error").hide();

    $("#map").ready(function(){
        console.log("Ready");
    });

    $("#btnSignIn").click(function(e){
        e.preventDefault();
        //temp for time saving
        $("#email").val("pperic@gmail.com");
        $("#error").hide();
        $("#error").empty();
        if(($("#email").val() != "") && ($("#password").val() != "")){
            var email = $("#email").val();
            var password = $("#password").val();

            //temp if for working with mock api
            if(password == "1234"){
                // JSON: {"name":"Pero", "surname":"Peric", "email":"pperic@gmail.com", "username": "pperic", "rolse_id":1}
                var URL = "https://mocki.io/v1/71c3eef6-f4ca-43f3-ae8f-16524480bff1";
            }else{
                //JSON: {"name":null, "surname":null, "email":null, "username": null, "rolse_id":null}
                var URL = "https://mocki.io/v1/e27d8a2f-574f-4cfd-bfb3-a9b1dde4bcf5";
            }

            //SEND: email,password RECEIVE: name, surname, email, username, role_id
            //check ajax request! and chect request type on confluence

            //COVERT TO POST request type!!
            $.ajax({type: "GET", url: URL, data: {email: email, password: password}, dataType: "json", complete: function(data){
                var user = $.parseJSON(data.responseText);
                
                //change to role_id!
                if(user["name"] != null && user["rolse_id"] == 1){
                    //set cookie to check login status
                    window.location.replace("./dashboard.html");
                }else{
                    $("#error").show();
                    $("#error").append("<span>Incorrect email or password!</span>");
                }
            }});
        }else{
            $("#error").show();
            $("#error").append("<span>Incorrect email or password!</span>");
        }
    });
});

function initMap() {
    //Get data from API (APIs URL)
    //Fake API for testing purposes
    //JSON content of the response: {"a":{"id":"TG_001", "product":"Baguette", "quantity":"10", "lat":46.22306, "lon":16.12, "online":1}, "b":{"id":"TG_002", "product":"Muffin", "quantity":"7", "lat":46.30444, "lon":16.33778, "online":2}, "c":{"id":"TG_003", "product":"Baguette", "quantity":"15", "lat":46.24306, "lon":16.20, "online":1}}
    var URL = "https://mocki.io/v1/46d798a1-a31f-41ff-b9b4-dcf925ac5abf";
    $.ajax({type: "GET", url: URL, dataType: "json", complete: function(data){
        var gates = $.parseJSON(data.responseText);
        
        const fistGate = { lat: gates["a"].lat, lng: gates["a"].lon };
        
        const map = new google.maps.Map(document.getElementById("map"), {
        zoom: 11,
        center: fistGate,
        });

        for(g in gates){
            const location = {lat: gates[g].lat, lng: gates[g].lon};
            setMarker(location, map, gates[g].id, gates[g].product, gates[g].quantity, gates[g].online);
        }

    }});
    
}

function setMarker(location, map, gateID, product, quantity, online){
    var infowindow = new google.maps.InfoWindow({
        content: "<h6>"+gateID+"</h6><span>Product: "+product+"<br>Quantity: "+quantity+"<br><br>Last online: "+online+" min ago</span>"
    });

    const marker = new google.maps.Marker({
        position: location,
        map: map,
    });

    marker.addListener("click", () => {
        infowindow.open(map, marker);
    });
}