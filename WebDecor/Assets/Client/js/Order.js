var order = {
    init: function () {
        order.orderEvents();
    },
    orderEvents: function () {
        $('#btnOrder').off('click').on('click', function () {
            var name = $('#txtName').val();
            var address = $('#txtAddress').val();
            var phone = $('#txtPhone').val();
            var email = $('#txtEmail').val();
            var note = $('#txtNote').val();

            $.ajax({
                url: '/Order/CreateOrder',
                type: 'POST',
                dataType: 'json',
                data: {
                    name: name,
                    address = address,
                    email: email,
                    phone: phone,
                    note: note,
                },
                success: function (res) {
                    if (res.status === true) {
                        alert('Thêm thành công!');
                        console.log('XXX');
                        contact.resetForm();
                    }
                }
            });
        });
    },
    resetForm: function () {
        $('#txtName').val('');
        $('#txtAddress').val('');
        $('#txtPhone').val('');
        $('#txtEmail').val('');
        $('#txtNote').val('');
    }
}
order.init();