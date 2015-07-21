
$(document).ready(function () {
    $('#carForm').validate({
        rules: {
            Make: {
                required: true
            },
            Model: {
                required: true
            },
            Year: {
                required: true
            },
            ImageUrl: {
                required: true
            },
            Title: {
                required: true
            },
            Price: {
                required: true
            },
        },
        messages: {
            Make: "Enter vehicle make",
            Model: "Enter vehicle model",
            Year:  "Enter vehicle year",
            ImageUrl: "Enter vehicle's image url",    
            Title: "Enter vehicle title",
            Price: "Enter vehicle price"
        }
    });
});
