$(document).ready(function(){
    console.log("JavaScript is connected.");
    
    //SIGN IN code
    if(!checkSignInCookie()){
        var path = window.location.pathname;
        var page = path.split("/").pop().split(".")[0];
        if(page != "signIn"){
            window.location.replace("./signIn.html");
        }
    }

    $("#error").hide();
    $("#error-CU").hide();
    $("#action-info").hide();

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
                    var expDate = new Date;
                    expDate.setDate(parseInt(expDate.getDate()) + parseInt(1));
                    var cookieString = "signedIn=" + user["username"] + "; expires=" + expDate + ";path=/";
                    document.cookie = cookieString;

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

    $("#sign-out").click(function(e){
        var expDate = new Date;
        var cookieString = "signedIn=null; expires=" + expDate + ";path=/";
        document.cookie = cookieString;
    });

    function checkSignInCookie(){
        var cookies = document.cookie.split('; ');
        if(cookies !== null){
            for(var i=0; i<cookies.length; i++){
                var cookieName = cookies[i].split('=');
                if(cookieName[0] === "signedIn"){
                    if(cookieName[1] !== "null"){
                        return true;
                    }else{
                        return false;
                    }
                }
            }
            return false;
        }
        else{
            return false;
        }
    }

    //GATES PAGE code
    if($("#table-gates").length > 0){
        var path = window.location.href;
        var attributes = path.split("/").pop().split("?");
        if(attributes[1]){
            $("#action-info").empty();

            var gateData = attributes[1].split('&');
            var gateId = gateData[0].split('=')[1];
            var action = gateData[1].split('=')[1];

            if(action === "1"){
                if(confirm("Are you sure you want to deactivate gate " + gateId + "?")){
                    //URL for disabling the gate
                    var URL = "https://mocki.io/v1/98c398aa-3422-469d-b485-55c1cc7ac0db";
                    //type is PATCH
                    $.ajax({type: "GET", url: URL, data: {gate_id: gateId}, dataType: "json", complete: function(data){
                        var msg = $.parseJSON(data.responseText);
                        if(msg["action"] === "success"){
                            $("#action-info").append("<span>Gate is successfully deactivated!</span>");
                        }
                        else{
                            $("#action-info").append("<span>An error occurred!</span>");
                        }
                    }});
                }
                else{
                    window.location.replace("./gates.html");
                }
            }
            else{
                if(confirm("Are you sure you want to activate gate " + gateId + "?")){
                    //URL for enabling the gate
                    var URL = "https://mocki.io/v1/98c398aa-3422-469d-b485-55c1cc7ac0db";
                    //type is PATCH
                    $.ajax({type: "GET", url: URL, data: {gate_id: gateId}, dataType: "json", complete: function(data){
                        var msg = $.parseJSON(data.responseText);
                        if(msg["action"] === "success"){
                            $("#action-info").append("<span>Gate is successfully activated!</span>");
                        }
                        else{
                            $("#action-info").append("<span>An error occurred!</span>");
                        }
                    }});
                }
                else{
                    window.location.replace("./gates.html");
                }
            }
            $("#action-info").show();
            loadGates();
        }
        else{
            loadGates();
        }
    }
    
    function loadGates(){
        $("#table-gates").empty();
        //mock data: {"a":{"gate_id":"TG_001", "product_name": "Baguette", "quantity": 10, "lat": 46.309436, "lon": 16.329482, "price": 1.50, "keepalive_time":"2022-12-28 11:44:56", "active": 1, "todays_sales": 15, "yesterdays_sales": 23}, "b":{"gate_id":"TG_002", "product_name": "Croissant", "quantity": 15, "lat": 45.309436, "lon": 15.329482, "price": 1.25, "keepalive_time":"2022-12-28 11:45:26", "active": 0, "todays_sales": 29, "yesterdays_sales": 28}, "c":{"gate_id":"TG_003", "product_name": "Muffin", "quantity": 7, "lat": 47.309436, "lon": 17.329482, "price": 2.00, "keepalive_time":"2022-12-28 11:45:45", "active": 1, "todays_sales": 7, "yesterdays_sales": 10}}

        var URL = "https://mocki.io/v1/18629954-0762-4f63-9013-bcca3a78f10e";

        $.ajax({type: "GET", url: URL, dataType: "json", complete: function(data){
            var gates = $.parseJSON(data.responseText);
            var table = '<table class="table table-striped table-hover">'+
            '<thead>'+
              '<tr>'+
                '<th scope="col">Gate name</th>'+
                '<th scope="col">Product name</th>'+
                '<th scope="col">Quantity</th>'+
                '<th scope="col">Price(€)</th>'+
                '<th scope="col">Sales today</th>'+
                '<th scope="col">% of yesterday</th>'+
                '<th scope="col">Last online</th>'+
                '<th scope="col">Edit gate</th>'+
                '<th scope="col">(De)Activate gate</th>'+
              '</tr>'+
            '</thead>'+
            '<tbody>';

            for(g in gates){
                if(gates[g].active ===  1)
                    var btn_text = "Deactivate";
                else
                    var btn_text = "Activate";

                table += '<tr>'+
                '<th scope="row">'+gates[g].gate_id+'</th>'+
                '<td>'+gates[g].product_name+'</td>'+
                '<td>'+gates[g].quantity+'</td>'+
                '<td>'+gates[g].price+'</td>'+
                '<td>'+gates[g].todays_sales+'</td>'+
                '<td>'+Math.round(((gates[g].todays_sales/gates[g].yesterdays_sales)*100)*100)/100+'</td>'+
                '<td>'+Math.floor((Date.now() - new Date(gates[g].keepalive_time))/60000)+' min</td>'+
                '<td><a href="./gatesCU.html?'+gates[g].gate_id+'">Edit</a></td>'+
                '<td><a href="./gates.html?gateId='+gates[g].gate_id+'&action='+gates[g].active+'"">'+btn_text+'</a></td>'+
                '</tr>';
            }
            table += '</tbody></table>';
            $("#table-gates").append(table);
        }});
    }

    $("#new-gate-btn").click(function(e){
        window.location.replace("./gatesCU.html");
    });

    //ADD NEW OR EDITING GATES PAGE code
    if($("#CU-section").length > 0){
        gateCU();
    }

    function gateCU(){
        var path = window.location.href;
        var action = path.split("/").pop().split("?")[1];
        if(action){
            $("#page-name-CU").empty();
            $("#page-name-CU").append("Edit gate");
            var URL = "https://mocki.io/v1/7520ad1c-9b04-4f1a-80d0-60a74363f669";
            $.ajax({type: "GET", url: URL, data: {gate_id: action}, dataType: "json", complete: function(data){
                var gate = $.parseJSON(data.responseText);
                $("#productName").val(gate["product_name"]);
                $("#quantity").val(gate["quantity"]);
                $("#price").val(gate["price"]);
                $("#lon").val(gate["lon"]);
                $("#lat").val(gate["lat"]);
            }});
        }else{
            $("#page-name-CU").empty();
            $("#page-name-CU").append("Create new gate");
            $("#productName").val();
            $("#quantity").val();
            $("#price").val();
            $("#lon").val();
            $("#lat").val();
        }
    }

    $("#btn-cancel").click(function(e){
        e.preventDefault();

        $("#productName").val();
        $("#quantity").val();
        $("#price").val();
        $("#lon").val();
        $("#lat").val();

        window.location.replace("./gates.html");
    });

    $("#btn-save").click(function(e){
        e.preventDefault();
        //URL for adding new gate or editing existing one; ID, keepalive and active status is sorted by API
        if($("#productName").val() != "" && $("#quantity").val() != "" && $("#price").val() != "" && $("#lon").val() != "" && $("#lat").val() != ""){
            $("#error-CU").hide();
            var path = window.location.href;
            var action = path.split("/").pop().split("?")[1];
            if(action)
                var URL = ""; //URL for edit gate
            else
                var URL = ""; // URL for creating inew gate
    
            $.ajax({type: "POST", url: URL, data: {product_name: $("#productName").val(), quantity: $("#quantity").val(), latitude: $("#lat").val(), longitude: $("#lon").val(), price: $("#price").val()}, dataType: "json", complete: function(data){
            }});
    
            window.location.replace("./gates.html");
        }
        else{
            $("#error-CU").show();
            $("#error-CU").append("<span>Some fields are empty!</span>");
        }
        
    });

    //REPORTS PAGE code
    if($("#table-reports").length > 0){
        LoadUsers();
        LoadReports("none");
    }

    function LoadUsers(){
        //get all users
        //users json {"a":{"user_id": 1, "username": "iivic", "active": 1, "role_id": 1}, "b":{"user_id": 2, "username": "ihorvat", "active": 1, "role_id": 2}, "c":{"user_id": 3, "username": "johny", "active": 1, "role_id": 2}, "d":{"user_id": 4, "username": "jeremy", "active": 1, "role_id": 2}, "e":{"user_id": 5, "username": "markovic", "active": 0, "role_id": 2}}
        var URL = "https://mocki.io/v1/f0794ea0-afe3-4132-b024-b7d6730933bf";
            $.ajax({type: "GET", url: URL, dataType: "json", complete: function(data){
                var users = $.parseJSON(data.responseText);
                var options = "";
                for(u in users){
                    if(users[u].role_id !== 1){
                        options += "<option value='" + users[u].user_id + "'>" + users[u].username + "</option>";
                    }
                }
                $("#users").append(options);
            }});
    }

    function LoadReports(filter){
        $("#table-reports").empty();
        if(filter !== "none"){
            //code for loading reports for specific user
            //json for user: {"a":{"username": "ihorvat", "product": "Baguette", "action":"purchase made", "gate": "TG_001", "date": "2022-11-05 10:10:10"}, "b":{"username": "ihorvat", "product": "Bread", "action":"purchase made", "gate": "TG_002", "date": "2022-11-06 10:10:10"}, "c":{"username": "ihorvat", "product": "Muffin", "action":"purchase declined", "gate": "TG_003", "date": "2022-11-07 10:10:10"}}
            var URL = "https://mocki.io/v1/eb6ddaa1-1216-4066-98d9-fdc542cf50af";
            $.ajax({type: "GET", url: URL, data: {userId: filter}, dataType: "json", complete: function(data){
                var reports = $.parseJSON(data.responseText);
                var table = '<table class="table table-striped table-hover">' +
                '<thead>' +
                  '<tr>' +
                    '<th scope="col">User</th>' +
                    '<th scope="col">Product</th>' +
                    '<th scope="col">Action</th>' +
                    '<th scope="col">Gate</th>' +
                    '<th scope="col">Date and time</th>' +
                  '</tr>' +
                '</thead>' +
                '<tbody>';
                for(r in reports){
                    table += '<tr>' +
                    '<th scope="row">' + reports[r].username + '</th>' +
                    '<td>' + reports[r].product + '</td>' +
                    '<td>' + reports[r].action + '</td>' +
                    '<td>' + reports[r].gate + '</td>' +
                    '<td>' + reports[r].date + '</td>' +
                  '</tr>';
                }
                table += '</tbody></table>';
                $("#table-reports").append(table);
            }});
        }
        else{
            //code for loading all reports
            //json for allusers {"a":{"username": "ihorvat", "product": "Baguette", "action":"purchase made", "gate": "TG_001", "date": "2022-11-01 10:10:10"}, "b":{"username": "johny", "product": "Bread", "action":"purchase made", "gate": "TG_002", "date": "2022-11-02 10:10:10"}, "c":{"username": "jeremy", "product": "Muffin", "action":"purchase made", "gate": "TG_003", "date": "2022-11-03 10:10:10"}, "d":{"username": "markovic", "product": "Bagel", "action":"purchase made", "gate": "TG_004", "date": "2022-11-04 10:10:10"}, "e":{"username": "jeremy", "product": "Muffin", "action":"purchase made", "gate": "TG_005", "date": "2022-11-05 10:10:10"}, "f":{"username": "johny", "product": "Baguette", "action":"purchase made", "gate": "TG_001", "date": "2022-11-06 10:10:10"}}
            var URL = "https://mocki.io/v1/d6e950ab-697a-4e84-9c16-7e3155351df6";
            $.ajax({type: "GET", url: URL, dataType: "json", complete: function(data){
                var reports = $.parseJSON(data.responseText);
                var table = '<table class="table table-striped table-hover">' +
                '<thead>' +
                  '<tr>' +
                    '<th scope="col">User</th>' +
                    '<th scope="col">Product</th>' +
                    '<th scope="col">Action</th>' +
                    '<th scope="col">Gate</th>' +
                    '<th scope="col">Date and time</th>' +
                  '</tr>' +
                '</thead>' +
                '<tbody>';
                for(r in reports){
                    table += '<tr>' +
                    '<th scope="row">' + reports[r].username + '</th>' +
                    '<td>' + reports[r].product + '</td>' +
                    '<td>' + reports[r].action + '</td>' +
                    '<td>' + reports[r].gate + '</td>' +
                    '<td>' + reports[r].date + '</td>' +
                  '</tr>';
                }
                table += '</tbody></table>';
                $("#table-reports").append(table);
            }});
        }
    }

    //when selection changes this function is executed
    $("#users").change(function(){
        LoadReports($(this).val());
    });

    //STATISTICS PAGE code
    //todo
});


//GOOGLE MAP code
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