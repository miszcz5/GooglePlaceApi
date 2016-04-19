var currentLocation = {

};
var details = null;
function Init() {
    var table = $('#example').DataTable({
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
    $('#Add').bind("click", AddLocation);

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
            "url": "api/places/GetBars",
            "type": "GET",
            "data": location
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
        success: function(data) {
            $('#target').html(data.msg);
        },
        data: currentLocation
    });
}


$(document).ready(function() {
    Init();
});
