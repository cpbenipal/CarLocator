var $jq = jQuery.noConflict();
$jq(document).ready(function () { 

    var table = $jq('#vehiclesTable').DataTable({
        "processing": true,
        "serverSide": false,         
        "columns": [
            { "data": "id", "orderable": false },
            { "data": "vin" },
            { "data": "make" },
            { "data": "model" },
            { "data": "color" },
            { "data": "year" },
            { "data": "boundStatus" },
            { "data": "companyName" },
            {
                "data": "pickedOn",
                "render": function (data, type, row) {
                    if (!data) return ""; // Handle empty dates
                    let date = new Date(data);
                    return date.toLocaleDateString('en-US', {
                        year: 'numeric',
                        month: '2-digit',
                        day: '2-digit',
                        hour: '2-digit',
                        minute: '2-digit',
                        hourCycle: 'h23'  
                    });
                }
            }
        ],
        "order": [[1, "asc"]], // Default sorting by VIN
        "lengthMenu": [10, 25, 50, 100] // Number of records per page
    });

    $jq("#searchButton").on("click", function (e) {
        let vin = $jq("#vinInput").val();
        $jq("#errorMessage").hide(); 

        if (vin === "") {
            $jq("#errorMessage").text("Please enter a VIN").show();
            return;
        }
        else {
            $.ajax({
                url: `/api/search/searchbyvin?vin=${vin}`,
                type: "GET",
                success: function (response) {
                    table.clear().rows.add(response.data).draw(); // Clear and reload data
                },
                error: function (xhr) {
                    alert(xhr.responseJSON?.message || "No vehicle found.");
                    table.clear().draw(); // Clear table if no data found
                }
            });
        }
    });
});
 