$('#show_reply').on('click', function (evt) {
    evt.preventDefault();
    evt.stopPropagation();

    for (var i = 0; i < 100; i++) {
        if (this.className !== "open comment_ńumber") {
            $("closed comment_number").toggleClass("open comment_number");
            $('#add_subcomment_' + i).load("/comment/reply");
        } else {
            $("open comment_number").toggleClass("i}closed comment_number");
            $('#add_subcomment_' + i).load("/comment/reply/empty")
        }
    }
});