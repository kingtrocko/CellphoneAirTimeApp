
$(function() {

    // Form components
    // ------------------------------

    // Select2 selects
    $('.select').select2({
        minimumResultsForSearch: '-1'
    });


    // Styled file input
    $(".file-styled").uniform({
        wrapperClass: 'bg-warning',
        fileButtonHtml: '<i class="icon-googleplus5"></i>'
    });


    // Styled checkboxes, radios
    $(".styled").uniform({
        radioClass: 'choice'
    });


    // Setup validation
    // ------------------------------

    var validateOptions = {
        lang: 'ES',
        ignore: 'input[type=hidden], .select2-input', // ignore hidden fields
        errorClass: 'validation-error-label',
        highlight: function(element, errorClass) {
            $(element).removeClass(errorClass);
        },
        unhighlight: function(element, errorClass) {
            $(element).removeClass(errorClass);
        },
        validClass: "validation-valid-label",
        success: function(label) {
            $(label).remove();
        },
        rules: {
            vali: "required",
            password: {
                minlength: 6,
                maxlength: 16
            },
            repeat_password: {
                equalTo: "#password"
            },
            user_name: {
                minlength: 2,
                maxlength: 30
            },
            user_last_name: {
                minlength: 2,
                maxlength: 30
            },
            addrress1: {
                minlength: 5,
                maxlength: 100
            },
            addrress2: {
                minlength: 5,
                maxlength: 100
            },
            username: {
                minlength: 5,
                maxlength: 14
            },
            email: {
                email: true
            },
            phonenumber: {
                minlength: 5
            }

        }
    }

    // Initialize validation
    $("form").each(function () {
        $(this).validate(validateOptions);
    });
});
