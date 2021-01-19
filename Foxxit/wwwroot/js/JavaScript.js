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
    let id = this.getAttribute("data-postBaseId");
    let value = this.getAttribute("data-value");
    debugger;
    $.getJSON("/vote/" + value + "/" + id, function (data) {
        debugger;
        var karma = data.karma
        var currentVote = data.currentVote
        $('#karma_' + id).html(karma)

        if (currentVote == 1) {
            $('#upvote_' + id).toggleClass("red");
            if ($('#downvote_' + id).hasClass("red")) {
                $('#downvote_' + id).toggleClass("red");
            }
        }
        if (currentVote == -1) {
            $('#downvote_' + id).toggleClass("red");
            if ($('#upvote_' + id).hasClass("red")) {
                $('#upvote_' + id).toggleClass("red");
            }
        }
    });
    //$('#karma_' + id).load("/vote/" + value + "/" + id),
});