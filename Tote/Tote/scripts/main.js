
window.JsonClass = function (urlGet, urlPost) {
    var _urlGet = urlGet;
    var _urlPost = urlPost;
    var _inProgress = false;

    function _makeCall(typeReq, urlReq, getData, callback) {
        //$("#lblResult").hide();
        if (!_inProgress) {
            $.ajax({
                type: typeReq,
                url: urlReq,
                data: getData(),
                beforeSend: function () {
                    _inProgress = true;
                },
                success: function (result) {
                    callback(result);
                },
                error: function (e) {
                    console.log(e);
                },
                complete: function () {
                    _inProgress = false;
                }
            });
        }
    }

    function GetMessageByCode() {
        var callback = function (result) {
            var label = $("#lblMesg");
            label.text(result.message);
        }
        var getData = function () {
            var code = $(".codeCss");
            var data = { id: code.val() };
            return data;
        }
        _makeCall("Get", _urlGet, getData, callback);
    }

    function SaveNewMessage() {
        var callback = function () {
            $("#lblResult").show();
        }

        var getData = function () {
            var newMSg = $("#txtNewMsg").val();
            var data = { message: newMSg };
            return data;
        }

        _makeCall("Post", _urlPost, getData, callback);
    }

    return {
        GetMessageByCode: GetMessageByCode,
        SaveNewMessage: SaveNewMessage
    };
}