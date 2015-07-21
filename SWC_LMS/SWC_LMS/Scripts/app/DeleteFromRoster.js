function deleteRegistration() {
    $('.Delete').click(DoDelete);
};

function DoDelete(){
        var Ids = {
            studentId: $(this).data('studentid'),
            courseId: $(this).data('courseid')
        };
        var courseId = $(this).data('courseid');

        $.post("/api/Delete/", Ids, function (data) {
            $("#displaybody").empty();

            $.each(data, function (key, value) {
                var firstName = value.FirstName;
                var lastName = value.LastName;
                var Email = value.Email;
                var Id = value.StudentId;
                var $log = $("#displaybody"),
                    str = "<tr><td class=LastName>" + lastName + "</td><td class=FirstName>" + firstName + "</td><td class=Email>" + Email + "</td><td align=center><span class=\"glyphicon glyphicon-trash Delete\" data-studentid=" + Id +" data-courseid="+ courseId +" ></span></td></tr>",
                    html = $.parseHTML(str);
                $log.append(html); 
            });
            deleteRegistration();
        });
};
$(document).ready(deleteRegistration());
