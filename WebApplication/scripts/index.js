var currentLocation = {
    Latitude: 50.0612603,
    Longitude: 19.9369816
};
var details = null;
var table = null;
function Init() {
    ShowLocations();
    $('#add').bind("click", AddLocation);

    $('#example tbody').on('click', 'tr', function() {
        if ($(this).hasClass('selected')) {
            $(this).removeClass('selected');
        }
        else {
            table.$('tr.selected').removeClass('selected');
            $(this).addClass('selected');
            var items = this.innerText.split('	');
            ShowBars({ Latitude: items[0], Longitude: items[1] });
        }
    });
    ShowBars(currentLocation);
}

function ShowLocations() {
    if (table !== null) {
        table.destroy();
    }
    table = $('#example').DataTable({
        "serverSide": true,
        "filter": false,
        "info": false,
        "paging": false,
        "ajax": {
            "url": "api/places/AllLocations",
            "type": "GET"
        },
        "columns": [
            { "data": "Latitude" },
            { "data": "Longitude" }
        ]
    });
}

function ShowBars(location) {
    if (details !== null) {
        details.destroy();
    }
    details = $('#details').DataTable({
        "serverSide": true,
        "filter": false,
        "info": false,
        "paging": false,
        "ajax": {
            "url": "api/places/GetBars?&latitude=" + location.Latitude + "&longitude=" + location.Longitude,
            "type": "GET"
        },
        "columns": [
            { "data": "Name" }
        ]
    });
}

function AddLocation() {
    $.ajax({
        url: '/api/places/AddLocation',
        type: 'post',
        dataType: 'json',
        data: currentLocation
    });
    ShowLocations();
}

$(document).ready(function() {
    Init();
});
