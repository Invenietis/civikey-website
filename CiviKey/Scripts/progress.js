$(function () {
    $(".show-more-features").click(function () {
        $(".hidden-feature").removeClass("hidden-feature");
        $(this).remove();
    })
});

