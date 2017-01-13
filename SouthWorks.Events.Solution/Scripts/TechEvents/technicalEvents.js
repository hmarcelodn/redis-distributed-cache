$(document).ready(function () {
    $('#technicalEventsList').dataTable({
        "bProcessing": true,
        "bServerSide": true,
        "sAjaxSource": "/Events/GetEvents",
        "aoColumns": [
			{ "sTitle": "Title" },
            { "sTitle": "Technology" },
            { "sTitle": "StartingDate" },
            { "sTitle": "RegistrationDate" }
        ]
    });
});