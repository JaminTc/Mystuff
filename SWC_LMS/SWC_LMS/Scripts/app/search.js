$(function() {
    $('.search-btn').click(function() {

        var $user = $('.user');
        var user = {
            FirstName : $user.find('input[name="FirstName"]').val(),
            LastName : $user.find('input[name="LastName"]').val(),
            Email: $user.find('input[name="Email"]').val(),
            Role: $user.find('#Role').val()
            };

        $.post("/api/admin", user, function (data) {
            $("#displaybody").empty();
            
            $.each( data, function(key,value) {
                var firstName = value.FirstName;
                var lastName = value.LastName;
                var Email = value.Email;
                var Role = value.Role;
                var Id = value.Id
                var $log = $("#displaybody"),
                    str = "<tr><td class=LastName>" + lastName + "</td><td class=FirstName>" + firstName + "</td><td class=Email>" + Email + "</td><td class=SuggestedRole>" + Role + "<td align=center><a href=/Admin/Edit/" + Id + ">details</a></td></tr>",
                    html = $.parseHTML(str);
                $log.append(html);
            });
        });
    });
});