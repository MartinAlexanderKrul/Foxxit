function hideComments() {
    var x = document.getElementById("comment_container");
    if (x.style.display === "block") {
        x.style.display = "none";
    } else {
        x.style.display = "block";
    }
}