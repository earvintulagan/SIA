$(document).ready(function () {

    $("#loginForm").validate({
        rules: {
            Username: {
                required: true
            },
            Password: {
                required: true
            }
        },
        messages: {
            Username: {
                required: "Username cannot be empty"
            },
            Password: {
                required: "Password cannot be empty"
            }
        },
        submitHandler: function (form) {
            var url = $(form).attr("action");
            var data = $(form).serialize();
            $.ajax({
                url: url,
                type: "POST",
                data: data,
                contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
                success: function (res) {
                    if (res == "True") {
                        window.location.href = "Home/Homepage";
                        
                    }
                    else {
                        
                        alert("Something went wrong");
                       
                    }
                },
                error: function (res) {

                }
            });
        }
    });
});
