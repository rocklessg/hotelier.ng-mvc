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


showInPopup = (url, title) => {
    $.ajax({
        type: "GET",
        url: url,
        success: function (res) {
            $('#form-modal .modal-body').html(res);
            $('#form-modal .modal-title').html(title);
            $('#form-modal').modal('show');
        }
    })
}

jQueryAjaxPost = form => {

    try {
        $.ajax({
            type: 'POST',
            url: form.action,
            data: new FormData(form),
            contentType: false,
            processData: false,
            success: function (res) {
                if (res.isValid) {
                    $("#hotel-list").html(res.html);
                    $('#form-modal .modal-body').html('');
                    $('#form-modal .modal-title').html('');
                    $('#form-modal').modal('hide');
                } else {
                    $('#form-modal .modal-body').html(res.html);
                }
            },
            error: function (err) {

            }
        })
    } catch (e) {

    }

    //to prevent default form submit
    return false;
}
