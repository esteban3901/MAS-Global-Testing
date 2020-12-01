var api = 'http://localhost:51551/api/';
function get(controller, id) {
    return new Promise(function (resolve, reject) {
        $.ajax({
            type: "GET",
            url: api + controller + '/' + id,
            beforeSend: function (request) {
                request.setRequestHeader("Content-Type", "application/json");
            },
            success: function (data) {
                resolve(data);
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                alert("Status: Unavailable Service");
            }  
        });
    });
}