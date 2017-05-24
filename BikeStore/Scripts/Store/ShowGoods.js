$().ready(function () {
    $.ajax({
        type: 'POST',
        url: '/Store/getGoods',
        data: $('#goodsList').serialize(),
        dataType: "json", //to parse string into JSON object,
        success: function (data) {
            if (data) {
                var len = data.length;
                var txt = "";
                if (len > 0) {
                    for (var i = 0; i < len; i++) {
                        if (data[i].Name && data[i].Price) {
                            txt += "<tr><td>" + data[i].Name + "</td><td>" + data[i].Price + "</td></tr>";
                        }
                    }
                    if (txt != "") {
                        $("#table").append(txt).removeClass("hidden");
                    }
                }
            }
        },
        error: function (jqXHR, textStatus, errorThrown) {
            alert('error: ' + textStatus + ': ' + errorThrown);
        }
    });
    return false;//suppress natural form submission
});