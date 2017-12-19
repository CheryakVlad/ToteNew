$(function () {
    $("#btnSort").click(function () {
        var sportId = $("#sport").val();
        var dateMatch = $('#dateField').val();
        var date_Match = new Date();
        if (dateMatch == '') {
            dateMatch = '';
        }
        else {
            var parts = dateMatch.split("-");
            dateMatch = parts[2] + '-' + parts[0] + '-' + parts[1];
        }

        var status = $('#status').val();

        $.ajax({
            type: 'GET',
            dataType: 'json',
            url: '/Sort/AjaxMethod?sportId=' + sportId + '&dateMatch=' + dateMatch + '&status=' + status,
            success: function (data) {
                $('#table > tbody').empty();

                $(data).each(function (index, item) {
                    var date = jsonDate(item.Date);
                    $('#table').append("<tr><td>" + item.Tournament.Name + "</td><td>" + item.Teams[0].Name + "</td><td>" + item.Teams[1].Name + "</td><td>" + date + "</td><td>" + item.Score + "</td><td></tr>");
                    $('#table').addClass('table');
                })
            }
        });
        $('#table').addClass('table');
    })
})