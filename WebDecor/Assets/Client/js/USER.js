var cart = {
    init: function () {
        cart.regEvents();
    },
    RegEvents: function () {
        $('#btnUpdate').off('click').on('click', function () {
            var listProduct = $('.SL');
            var cartList = [];
            $.each(listProduct, function (i, item) {
                cartList.push({
                    SL: $(this).val(),
                });
            });
        });
    }
}