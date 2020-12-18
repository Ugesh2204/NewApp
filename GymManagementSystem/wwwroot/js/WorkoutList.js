var dataTable;

$(document).ready(function () {

    dataTable = $('#DT_Load').DataTable({
        "ajax": {
            "url": "/FitnessWorkout/GetAllApiJson",
            "type": "GET",
            "datatype":"json"

        },
        "columns": [
            {
                "data": "WorkoutId",
                "width":"20%"
            },
            {
                "data": "WorkoutName",
                "width": "20%"
            },
            {
                "data": "ImageURL",
                "width": "20%"
            },
            {
                "data": "MaxParticpant",
                "width": "20%"
            },
            {
                "data": "Price",
                "width": "20%"
            },

        ],
        "language": {
            "emptyTable":"Not Found Data"
        },
        "width":"100%"


    });

});