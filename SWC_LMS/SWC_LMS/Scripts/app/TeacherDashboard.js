$(function () {
    $('.Course').on('click', function () {
        var courseid = $(this).data('courseid');
        var url = "/Teacher/GetThisCourse/" + courseid;
        window.location.href = url;
    });

   
});

function getArchivedReg() {
    $('#archived').click(getArchived);
}

function getArchived() {
    var teacherid = $(this).data('teacherid');

    $.get("/api/Teacher/" + teacherid, function(data) {
        $.each(data, function (key, value) {
            var courseName = value.CourseName;
            var Id = value.CourseId;
            var $log = $("#displaybody"),
                str = "<tr class=\"classbox Course\" data-courseid=" + Id + "><td><div class=cellLeft>" + courseName + "</div></td></tr>",
                html = $.parseHTML(str);
            $log.append(html);
        });
        getArchivedReg();
    });
};

$(document).ready(getArchivedReg());
