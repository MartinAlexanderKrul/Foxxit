$('.show_reply').on('click', function (evt) {
    evt.preventDefault();
    evt.stopPropagation();

    let id = this.getAttribute("data-commentId");

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
    if ($(this).hasClass("closed")) {
        $(this).toggleClass("closed");
        $('#add_subcomment_' + id).load("/comment/reply/" + id);
    } else {
        $(this).toggleClass("closed");
        $('#add_subcomment_' + id).empty();
    }
});