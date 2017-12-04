$(function () {
    $("#menuSport li").each(function () {
        var id = $(this).attr("id");

        $.ajax({
            type: 'GET',
            url: '/Navigation/ChildTournament/' + id,
            success: function (data) {
                $('#menuSport > li#' + id).append(data);
            }
        });
    })
})