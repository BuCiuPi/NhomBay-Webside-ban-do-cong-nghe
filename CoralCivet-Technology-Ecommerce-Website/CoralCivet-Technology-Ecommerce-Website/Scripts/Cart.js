$(".js-add-cart").click(function (e) {
    var button = $(e.target);
    var Cart = button.attr("data-cart-id");
    $.post("/api/apiCart", { cart: button.attr("data-cart-id") }).done(function (result) {

    })
})