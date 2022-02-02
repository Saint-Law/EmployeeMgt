function ValidateAccount(validationUrl, myButton, lblMessage) {

    var accountId = $('#txtCustomerId').val();

    $.ajax({
        type: 'get',
        beforeSend: function () {
            $(myButton).text('Checking...');
            $(myButton).attr('disabled', 'disabled')
        },
        url: validationUrl + "?accountId=" + accountId,
        contentType: 'application/json; charset=UTF-8',
        success: function (response) {
            console.dir(response);

            if (response !== null) {
                if (response.responseCode == '00') {
                    $(lblMessage).text('Account Number Valid');
                }                
                else {
                    $(lblMessage).text(response.responseMessage);
                }
            }
            else {
                toastr.error('Oooops! An error occured while processing the request');
            }

        },
        error: function (err) {
            console.log(err);
            toastr.error('Error Occured while Processing Request');
        },
        complete: function () {
            $(myButton).text('Check Account');
            $(myButton).removeAttr('disabled');
        }
    })
};


function ValidateAccountForName(validationUrl, myButton, lblMessage) {

    var accountId = $('#txtCustomerId').val();

    $.ajax({
        type: 'get',
        beforeSend: function () {
            $(myButton).text('Checking...');
            $(myButton).attr('disabled', 'disabled')
        },
        url: validationUrl + "?accountId=" + accountId,
        contentType: 'application/json; charset=UTF-8',
        success: function (response) {
            console.dir(response);

            if (response !== null) {
                if (response.responseCode == '00') {
                    $(lblMessage).text('Account Number Valid');
                    $('#txtFullName').val(response.data);
                }
                else {
                    $(lblMessage).text(response.responseMessage);
                }
            }
            else {
                toastr.error('Oooops! An error occured while processing the request');
            }

        },
        error: function (err) {
            console.log(err);
            toastr.error('Error Occured while Processing Request');
        },
        complete: function () {
            $(myButton).text('Check Account');
            $(myButton).removeAttr('disabled');
        }
    })
};

function GetLoanType(urlBase) {

    $('#drpLoanType').empty();
    $('#drpLoanType').append('<option selected="true" disabled>-Choose Loan Type-</option>')
    $.getJSON(urlBase, function (data) {
        console.log(data);
        let obj = Object.entries(data.data);
        for (let [key, value] of obj) {
            $('.#drpLoanType').append($('<option></option>')
                .attr('value', value.id)
                .text(value.name));
        }
    });
};
