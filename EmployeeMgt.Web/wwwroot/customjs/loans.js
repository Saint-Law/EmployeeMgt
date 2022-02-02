function LoanApplication(baseUrl, myButton, redirectUrl) {
    var $loanType = parseInt($('#drpLoanType option:selected').val());
    var $accountId = $('#txtCustomerId').val();
    var $customerName = $('#txtFullName').val();
    var $amount = parseInt($('#txtAmount').val());
    var $startDate = $('#txtStartDate').val();
    var $endDate = $('#txtEndDate').val();
    var $comment = $('#txtComment').val();

    var postedData = JSON.stringify
        ({
            "accountNumber": $accountId, "accountName": $customerName,
            "principalAmount": $amount, "loanType": $loanType,
            "startDate": $startDate, "endDate": $endDate,
            "comment": $comment
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
                    toastr.info('Loan Granted Successfully!');
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

function LoanDisbursal(baseUrl, myButton, redirectUrl) {
    var $loanType = parseInt($('#loanTypeId').val());
    var $loanId = parseInt($('#uId').val());
    var $accountId = $('#accountNumber').val();
    var $startDate = $('#startDate').val();
    var $endDate = $('#endDate').val();

    var postedData = JSON.stringify
        ({
            "Id": $loanId, "accountNumber": $accountId,
            "startDate": $startDate, "endDate": $endDate,
            "loanType": $loanType
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
                    toastr.info('Loan Disbursed Successfully!');
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


function LoanEditAdmin(baseUrl, myButton, redirectUrl) {
    var $loanId = parseInt($('#txtCustomerId').val());
    var $amount = parseFloat($('#loanAmount').val());

    var postedData = JSON.stringify
        ({
            "Id": $loanId, "LoanAmount": $amount
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
                    toastr.info('Loan Updated Successfully!');
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