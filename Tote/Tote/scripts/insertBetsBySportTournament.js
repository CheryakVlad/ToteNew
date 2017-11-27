$(function () {
    $("ul.menuTournament > li").click(function () {
        var sportId = $(this).attr("id");
        var tournamentId = $(this).attr("class");

        $.ajax({
            type: 'GET',
            url: '/Navigation/ListBet/?' + "SportId=" + sportId + "&TournamentId=" + tournamentId,
            success: function (data) {
                $('#list').replaceWith(data);

            }
        });
    })
})