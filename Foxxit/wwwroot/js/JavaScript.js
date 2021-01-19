$('.show_reply').on('click', function (evt) {
    evt.preventDefault();
    evt.stopPropagation();

    let id = this.getAttribute("data-commentId");

    if ($(this).hasClass("closed")) {
        $(this).toggleClass("closed");
        $('#add_subcomment_' + id).load("/comment/reply/" + id);
    } else {
        $(this).toggleClass("closed");
        $('#add_subcomment_' + id).empty();
    }
});

$('.post_vote').on('click', function (evt) {
    evt.preventDefault();
    evt.stopPropagation();
    debugger;
    let id = this.getAttribute("data-postBaseId");
    let value = this.getAttribute("data-value");

    $('#voting_' + id).empty();
    $('#voting_' + id).load("/vote/" + value + "/" + id);
});