var stripe = Stripe("pk_test_5104HR54ZriKXbh6h0S1vNDz3fKVbQIaI1ZmD5C5eVVvfp0LYdV5Y9tg2WMmPZrYfcPgHEOa0d9uHgmmWDFiaWcKX00K39qkg6J"); // Replace with your Stripe Publishable Key


$(document).ready(function () {
    $('#dvSubscription').hide();   
});

function ProcessPayment(plan) {
    var request = JSON.stringify({ plan: plan, name: $('#fullName').val(), email: $('#email').val() });
    console.log(request);
    $.ajax({
        url: '/api/SubscriptionPlan/PostSubscription',
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
            console.error("AJAX error:", error);
        }
    });
}
 
$(".GoToPlan").on("click", function (e) {
    e.preventDefault();     
    var plan = $(this).data("plan");
    $('#dvSubscription').show();
    //$('#hdnRole').val(plan.id);
    $("#Input_HdnPlanId").val(plan.id);
    $('#spanRole').html(plan.id == 1 ? "User" : "Business");     
});
 
$("#validationForm").on("submit", function (e) {
    e.preventDefault();     
    ProcessPayment($('#spanRole').html());
});

 