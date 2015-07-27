var ThisPercent;


$(function() {
    $(document).ready(ChangeThisGrade);
});


function ChangeThisGrade() {
    $('.percentage').click(ChangeGrade);
}

function ChangeGrade() {
    var AssignmentId = $(this).data('assignmentid');
    var userId = $(this).data('studentid');
    var back = $(this).data('idtag');
    ThisPercent = $("#" + back).text();

    
    $.post("/api/Grades/" + AssignmentId, function(thisGrade) {
        $("#" + back).empty();
        $('.percentage').off("click");

        var $log = $("#" + back),
            str = "<input class = grade style = width:25px;height:22px type = text > /" + thisGrade + "<span class=\"glyphicon glyphicon-ok save\" id=" + AssignmentId + userId + " data-idtag=" + AssignmentId + userId + " data-assignmentid=" + AssignmentId + " data-studentid=" + userId + "></span>",
            html = $.parseHTML(str);
        $log.append(html);
        $(document).ready(savePointsReg());
    });
};



function savePointsReg() {
    $('.save').click(savePoints);
};

function savePoints() {
    var grades = {
        AssignmentId: $(this).data('assignmentid'),
        PointsEarned: $('.grade').val(),
        UserId: $(this).data('studentid'),
        Percent: ThisPercent
}

    var back = $(this).data('idtag');
    $.post("/api/Grades", grades, function (data) {
        $("#" + back).empty();

        var percent = data.Precentage;
            var $log = $("#" + back),
                str = "<div class= percentage>" + percent + "<span>%</span></div>",
                html = $.parseHTML(str);
            $log.append(html);
        
    });
    var grade = $ ;
    $.post('/api/CurrentGrade/' + grades.UserId, function(currentGrade) {
        $('.Grade').empty();

        var $log = $('.Grade'),
            str = "<div class= Grade>" + currentGrade + "</div>",
            html = $.parseHTML(str);
        $log.append(html);
        $(document).ready(ChangeThisGrade);
    });
};
