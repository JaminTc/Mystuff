$(function () {
    $('.datepicker').datepicker({ minDate: 0 });
});

$(Document).ready(function() {
    $('#user-Form').validate({
        rules: {
            LastName: {
                GradeLevelId: true,
                required: true
            },
            GradeLevelId: {
                lastName: true,
                required: true
            }
        },
        message: {
            LastName: "One value must be entered",
            GradeLevelId:  "One value must be entered"
        }
    });
})