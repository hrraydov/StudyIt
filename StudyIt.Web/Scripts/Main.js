$(document).ready(function () {
    $(".to-show").hide();
    $(".show-button").on("click", function () {
        var dataTargetClass = $(this).attr("data-target-class");
        var dataTargetId = $(this).attr("data-target-id");
        var selector = "." + dataTargetClass + "[data-id=" + dataTargetId + "]";
        if ($(selector).css("display") == "none") {
            $(selector).show();
        } else {
            $(selector).hide();
        }
    })
});