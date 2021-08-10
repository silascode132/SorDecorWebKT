var contact = {
    init: function () {
        contact.registerEvents();
    },
    registerEvents: function () {
        $('#btnSend').off('click').on('click', function () {
            var name = $('#txtName').val();
            var email = $('#txtEmail').val();
            var phone = $('#txtPhone').val();
            var content = $('#txtContent').val();

            $.ajax({
                url: '/Contact/Send',
                type: 'POST',
                dataType: 'json',
                data: {
                    name: name,
                    email: email,
                    phone: phone,
                    content: content,
                },
                success: function (res) {
                    if (res.status === true) {
                        alert('Gửi thành công');
                        contact.resetForm();
                    }
                    else {
                        alert('Vui lòng đăng nhập trước khi gửi phản hồi');
                    }
                }
            });
        });
    },
    resetForm: function () {
        $('#txtName').val('');
        $('#txtEmail').val('');
        $('#txtPhone').val('');
        $('#txtContent').val('');
    }
}
contact.init();