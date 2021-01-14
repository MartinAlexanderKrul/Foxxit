$('#show_reply').on('click', function (evt) {
    evt.preventDefault();
    evt.stopPropagation();

    $('#add_subcomment').load("/comment/reply");
});