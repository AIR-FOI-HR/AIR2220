$(document).ready(function(){
    console.log("JS is connected.");
    $("#error").hide();

    $("#map").ready(function(){
        console.log("Ready");
    });

    $("#btnSignIn").click(function(e){
        e.preventDefault();
        $("#error").hide();
        $("#error").empty();
        if(($("#email").val() != "") && ($("#password").val() != "")){
            //change URL
            var email = $("#email").val();
            var password = $("#password").val();
            
            var URL = "MOCK_URL";
            //Hash password
            //var hashedPass = cypto.subtle.digest('SHA-256', new TextEncoder().encode("999"+password));
            //console.log(hashedPass);
            //SEND: email, RECEIVE: password, salt, role_id
            //check ajax request! and chect request type on confluence
            /*
            $.ajax({type: "GET", url: URL, dataType: "json", data: {email}, complete: function(data){
                var user = $.parseJSON(data.responseText);

                if(user["user_id"] != null){
                    var hashedPass = cypto.subtle.digest('SHA-256', new TextEncoder().encode(user["salt"]+password));
                    if(hashedPass == user["password"] && user["role_id"] == 1){
                        //set cookie to check login status
                        window.location.replace("./dashboard.html");
                    }else{
                        $("#error").show();
                        $("#error").append("<span>Incorrect email or password!</span>");
                    }
                }else{
                    $("#error").show();
                    $("#error").append("<span>Incorrect email or password!</span>");
                }
            }});*/
            if(email == "dcapek@foi.hr" && password == "1234"){
                window.location.replace("./dashboard.html");
            }else{
                $("#error").show();
                $("#error").append("<span>Incorrect email or password!</span>");
            }
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