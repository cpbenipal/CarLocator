$(() => {
    $("#aRenew").on("click", function (event) { 
        event.preventDefault();

        Swal.fire({
            title: "Are you sure?",
            text: "This action cannot be undone!",
            icon: "warning",
            showCancelButton: true,
            confirmButtonColor: "#d33",
            cancelButtonColor: "#3085d6",
            confirmButtonText: "Yes!"
        }).then((result) => {
            if (result.isConfirmed) {
                var request = JSON.stringify($(this).data('datac'));
                console.log(request);
                $.ajax({
                    url: "/api/SubscriptionPlan/RenewSubscription",
                    type: 'POST',
                    contentType: 'application/json',
                    data: request,
                    success: function (data) {
                        if (!data) {
                            console.error("Empty response from server");
                            return;
                        }

                        console.log("Subscription request successful:", data);

                        // Assuming the server returns the Stripe Checkout session URL
                        if (data.sessionUrl) {
                            // Redirect to Stripe Checkout page
                            window.location.href = data.sessionUrl;
                        } else {
                            console.error("Stripe session URL not found in response.");
                        }
                    },
                    error: function (xhr, status, error) {
                        console.error("AJAX error:", xhr + " - " + JSON.stringify(xhr) + " - " + error);
                    }
                });

            }
        });
    });

    $("#acancel").on("click", function (e) {
        e.preventDefault(); 
        Swal.fire({
            title: "Are you sure?",
            text: "This action cannot be undone!",
            icon: "warning",
            showCancelButton: true,
            confirmButtonColor: "#d33",
            cancelButtonColor: "#3085d6",
            confirmButtonText: "Yes!"
        }).then((result) => {
            if (result.isConfirmed) {
                var request = JSON.stringify({ subscriptionId: $(this).data('datac') });
                console.log(request);
                $.ajax({
                    url: "/api/SubscriptionPlan/CancelSubscription",
                    type: 'POST',
                    contentType: 'application/json',
                    data: request,
                    success: function (data) {
                        if (!data) {
                            console.error("Empty response from server");
                            return;
                        }
                        else {
                            window.location.href = window.location.href;
                        }
                    },
                    error: function (xhr, status, error) {
                        console.error("AJAX error:", xhr + " - " + JSON.stringify(xhr) + " - " + error);
                    }
                });
            }
        });
    });
});

