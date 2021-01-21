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
    $.getJSON("/vote/" + value + "/" + id, function (data) {
        var karma = data.karma
        var currentVote = data.currentVote
        $('#karma_' + id).html(karma)
        debugger;
        if (currentVote == 1) {
            $('#upvote_' + id).addClass("green");
            $('#downvote_' + id).removeClass("red")
        }
        if (currentVote == 0) {
            $('#upvote_' + id).removeClass("green");
            $('#downvote_' + id).removeClass("red")
        }
        if (currentVote == -1) {
            $('#upvote_' + id).removeClass("green");
            $('#downvote_' + id).addClass("red")
        }
    });
});