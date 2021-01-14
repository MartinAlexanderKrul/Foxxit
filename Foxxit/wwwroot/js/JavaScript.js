$('.show_reply').on('click', function (evt) {
    evt.preventDefault();
    evt.stopPropagation();
    debugger;

    let id = this.getAttribute("data-commentId");

    if ($(this).hasClass("closed")) {
        $(this).toggleClass("open");
        $(this).toggleClass("closed");
        $('#add_subcomment_' + id).load("/comment/reply/" + id);
    } else {
        $(this).hasClass("open");
        $(this).toggleClass("closed");
        $(this).toggleClass("open");
        $('#add_subcomment_' + id).load("/comment/reply/empty")
    }
});