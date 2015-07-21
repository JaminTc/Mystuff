$(function () {
    $('.search-btn').click(function() {
        var $user = $('.user');
        var user = {
            LastName: $user.find('input[name="LastName"]').val(),
            GradeLevelId: $user.find('#GradeLevelId').val()
        };
        if (user.LastName === "" && user.GradeLevelId == null) {
            alert("One field must have a value");
        }
        else {
        var courseId = $(this).data('courseid');
        $("#displaySearch").empty();

        $.post("/api/Teacher", user, function (data) {

            $.each(data, function (key, value) {
                var lastName = value.LastName;
                var firstName = value.FirstName;
                var gradeLevel = value.GradeLevelName;
                var id = value.UserId;
                var $log = $("#displaySearch"),
                    str = "<tr><td class=LastName>" + lastName + "</td><td class=FirstName>" + firstName + "</td><td class= GradeLevel col-md-1>" + gradeLevel + "</td><td  align = center><span class =\"glyphicon glyphicon-plus Add\" data-studentid=" + id +" data-courseid="+ courseId + " style =  \"width: 22px; height: 23px; border: 2px groove #B5B1B1; padding: 0 0 0.25em 0.17em;\"></span></td></tr>",
                    html = $.parseHTML(str);
                $log.append(html);
            });
            addRegistration();
        });
        }
    });
});