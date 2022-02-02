function UploadWithdrawal(baseUrl, myButton, redirectUrl) {
    var $accountId = $('#txtCustomerId').val();
    var $customerName = $('#txtFullName').val();
    var $amount = parseFloat($('#txtAmount').val());
    var $withdrawDate = $('#txtWithdrawDate').val();
   

    var postedData = JSON.stringify
        ({
            "AccountNo": $accountId, "UserName": $customerName,
            "Amount": $amount, "WithdrawalDate": $withdrawDate
        });

    console.log(postedData);


    $.ajax({
        type: 'post',
        beforeSend: function () {
            $(myButton).text('Processing...');
            $(myButton).attr('disabled', 'disabled')
        },
        url: baseUrl,
        contentType: 'application/json; charset=UTF-8',
        data: postedData,
        success: function (response) {
            console.dir(response);

            if (response !== null) {
                if (response.responseCode == '00') {
                    toastr.info('Savings Withdrawal Made Successfully!');
                    RefreshAppUrl(redirectUrl);
                }
                else {
                    toastr.error(response.responseMessage);
                }
            }
            else {
                $('#dvErrorMessage').attr('hidden', 'hidden');
                toastr.error('Oooops! An error occured while processing your request');
            }

        },
        error: function (err) {
            console.log(err);
            $('#dvErrorMessage').attr('hidden', 'hidden');
            toastr.error('Error Occured while Processing your request');
        },
        complete: function () {
            $(myButton).text('Submit Request');
            $(myButton).removeAttr('disabled');
        }
    })
};