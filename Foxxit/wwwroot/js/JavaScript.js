//$('.load-comments').on('click', function (evt) {
//    evt.preventDefault();
//    evt.stopPropagation();

//    $('#comment_container_js').load("/loadComments");
//});

//$('.comment_number').on('click', function (evt) {
//    evt.preventDefault();
//    evt.stopPropagation();

//    $('#addcomment').load("/newComment");
//});

$(document).on('click', '#vote-btn', function (event) {
    $.ajax({
        url: '/vote',
        type: "post",
        contentType: 'application/json;charset=UTF-8',
        dataType: "json",
        data: JSON.stringify({
            'postBaseId': $('#vote-btn').data('postBaseId'),
            'value': value // ??
        }),
        success: function (response) {
            console.log(response);
        },
        error: function (xhr) {
            console.log(xhr);
        }
    });
    event.preventDefault();
});