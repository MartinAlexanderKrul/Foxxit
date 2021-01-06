$('.load-comments').on('click', function (evt) {
    evt.preventDefault();
    evt.stopPropagation();

    $('#comment_container_js').load("/loadComments");
});