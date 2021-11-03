function verifyInvite(url) {
    $.ajax({
        type: "POST",
        url: url,
        success: function (response) {
            $('#manager-requests').html(response);
            $.notify("Request approved successfully!", "success");
        },
        error: function (){
            $.notify("Request not successfully approved!", "error");
        }
    })
}