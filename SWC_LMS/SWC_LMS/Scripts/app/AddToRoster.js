function addRegistration() {
    $('.Add').click(DoAdd);
};

function DoAdd() {
        var ids = {
            studentId: $(this).data('studentid'),
            CourseId: $(this).data('courseid')
        };
        var courseId = $(this).data('courseid');

        $.post("/api/Add", ids, function (data) {
            $("#displaybody").empty();

            $.each(data, function (key, value) {
                var firstName = value.FirstName;
                var lastName = value.LastName;
                var Email = value.Email;
                var Id = value.StudentId;
                var $log = $("#displaybody"),
                    str = "<tr><td class=FirstName>" + firstName + "</td><td class=LastName>" + lastName + "</td><td class=Email>" + Email + "</td><td align=center><span class=\"glyphicon glyphicon-trash Delete\" data-studentid=" + Id + " data-courseid=" + courseId + " ></span></td></tr>",
                    html = $.parseHTML(str);
                $log.append(html);
            });
            deleteRegistration();
        });
    };

$(document).ready(addRegistration());