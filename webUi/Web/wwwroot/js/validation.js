$(function () {
    var $registerForm = $("#registration");
    $.validator.addMethod("space", function (value, element) {
        return value == ' ' || value.trim().length != 0
    }, "Spaces are not allowed");
    if ($registerForm.length) {
        $registerForm.validate({
            rules: {
                
                Email: {
                    required: true,
                    space: true
                },
                Password: {
                    required: true,
                    minlength: 8
                },
                ConfirmPassword: {
                    required: true,
                    equalTo: '#password'
                }
            },
            messages: {
                
                Email: {
                    required: 'Enter email'
                },
                Password: {
                    required: 'Enter password',
                    minlength: 'At least 8 symbols'

                },
                ConfirmPassword: {
                    required: 'Enter password',
                    equalTo: 'Enter the same password'
                }

            }
        })
    }
})