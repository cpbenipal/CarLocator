var stripe = Stripe("pk_test_5104HR54ZriKXbh6h0S1vNDz3fKVbQIaI1ZmD5C5eVVvfp0LYdV5Y9tg2WMmPZrYfcPgHEOa0d9uHgmmWDFiaWcKX00K39qkg6J"); // Replace with your Stripe Publishable Key
 
function ProcessPayment() {
    var request = JSON.stringify({ plan: $('#hdnRole').val(), name: $('#fullName').val(), email: $('#email').val(), subRoleId: $("input[name='subRole']:checked").val() });
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
                data.sessionUrl == "N" ? $(".text-danger").html("Email already exists") : window.location.href = data.sessionUrl;
            } else {
                console.error("Stripe session URL not found in response.");
            }
        },
        error: function (xhr, status, error) {
            console.error("AJAX error:", error);
        }
    }); 
} 
 
 
$("#validationForm").on("submit", function (e) {
    e.preventDefault();     
    ProcessPayment();
});
$('#exampleModal').on('show.bs.modal', function (event) {
    var label = $(event.relatedTarget);
    var modal = $(this);
    var plan = JSON.parse(label.attr("data-whatever"));  
    console.log(plan);
    $("#fullName").val("");
    $("#email").val("");
    if (plan.id == 1) {
        $("#hdnRole").val("user");
        modal.find('.modal-body #dvSubRole').hide();
        modal.find('.modal-title').text('User Subscription');
        $(".lblName").text("Full Name");
        $("#fullName").prop("placeholder", "Enter Full Name");
    }
    else {
        modal.find('.modal-body #hdnRole').val("business");
        modal.find('.modal-body #dvSubRole').show();
        modal.find('.modal-title').text('Business Subscription');
        $(".lblName").text("Company Name");
        $("#fullName").prop("placeholder", "Enter Company Name");
    }  
})
