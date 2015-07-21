
$(document).ready(function () {
    $('#rsvpForm').validate({
        rules: {
            Name: {
                required: true
            },
            PhoneNumber: {
                required: true
            },
            Email: {
                required: true,
                email: true
            },
            Income: {
                required: true
            }
        },
        messages: {
            Name: "Enter your name",
            PhoneNumber: "Enter your phone number",
            Email: {
                required: "Enter your email address",
                email: "That's not a format for email I'm aware of..."
            },
            Income: "Must enter valid amount!"
        }
    });
});
