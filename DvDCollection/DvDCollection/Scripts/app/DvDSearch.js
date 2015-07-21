$(function() {
    $("#src-btn").click(function () {
        var $movie = $(".movie-item");

        var Title = $movie.find('input[name="Title"]').val();
        var Director = $movie.find('input[name="Director"]').val();
        var Actor = $movie.find('input[name="Actor"]').val();
        $.each($('.tbody tr'), function(i, movieitem) {
            if (Title !== "") {
                if ($(movieitem).find('.thisTitle').text().indexOf(Title) === -1) {
                    $(movieitem).hide();
                }
            }
            if (Director !== "") {
                if ($(movieitem).find('.thisDirector').text().indexOf(Director) === -1) {
                    $(movieitem).hide();
                }
            }
            if (Actor !== "") {
                if ($(movieitem).find('.thisActor').text().indexOf(Actor) === -1) {
                    $(movieitem).hide();
                }
            }
        });
    });
    $("#save-btn").click(function() {
        var actors = $('div[name="actors"]').text.split(",");
        var actor = actors.Text.split(/ +/);

        $.ajax({
            type: 'POST',
            url: '/Movie/AddActor',
            dataType: 'json',
            contentType: 'application/json; charset=utf-8',
            data: JSON.stringify(actor),
            success: function() {
                alert('saved');
            }
        });
    });
});
