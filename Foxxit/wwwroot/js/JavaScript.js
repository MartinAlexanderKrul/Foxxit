$('.load-comments').on('click', function (evt) {
    evt.preventDefault();
    evt.stopPropagation();

    if (this !== 'open') {
        $('#comment_container_js').load("/loadComments");
        $('.closed').toggleClass("open");
    } else {
        $('open').toggleClass("closed");
        $('#comment_container_js').load('');
    }
});