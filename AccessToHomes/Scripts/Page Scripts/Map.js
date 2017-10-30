function loadScript() {
    var script = document.createElement("script");
    script.type = "text/javascript";
    script.src = "http://maps.google.com/maps/api/js?key=AIzaSyBqKTtuD649T6vQQ_VFHvJXjCyDiiqMQxQ&sensor=false&libraries=geometry&callback=pageLoad";
    document.body.appendChild(script);
}
window.onload = loadScript;
function getLocation(postcode, outputBox) {
    var geocoder = new google.maps.Geocoder();
    var location;


    geocoder.geocode({ 'address': postcode }, function (results, status) {

        if (status == google.maps.GeocoderStatus.OK) {
            var location = results[0].geometry.location+'';
            $('#' + outputBox).val(location.replace('(', '').replace(')', ''));
        }
    });
}
