$(function () {
    $("#menuSport > li > h3").click(function () {
        var sportId = $(this).attr("id");

        $.ajax({
            type: 'GET',
            url: '/Navigation/ListBet/?' + "SportId=" + sportId,
            success: function (data) {
                $('#list').replaceWith(data);

            }
        });

        if ($(this).parent().find('ul').length) {
            $(this).parent().find('ul').slideToggle(200);
            return false;
        }

    })
})