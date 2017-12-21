function SportChange() {
    var sportId = $('#SportId').val();
    $.ajax({
        type: 'GET',
        url: '/Match/TournamentesBySport?sportId=' + sportId,
        success: function (data) {
            $('#tournamentId').replaceWith(data).change();
            TournamentChange();
        }
    });

}