$(document).on('click', '.toggle-password', function () {
    $(this).toggleClass("fa-eye fa-eye-slash");
    var input = $(this).parents(".inner-addon").find(".pwd");
    //var input = $(".pwd");
    input.attr('type') === 'password' ? input.attr('type', 'text') : input.attr('type', 'password')
});