// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {
    $('#tblData').DataTable();
});

$(document).ready(() => {
    setTimeout(() => {
        var acc_no = new Date().getTime().toString();
        acc_no = acc_no.substr(3)
        $(".account_no").val(acc_no)
        $(".account_no").next().val(acc_no)
    }, 2000)
})


//$(document).ready(function () {
//    SearchText();
//})
//function SearchText() {
//    $("#txtCusName").autocomplete({
//        source: function (request, response) {
//            $.ajax({
//                type: "POST",
//                contentType: "application/json; charset=utf-8",
//                url: "LoanRequest/GetCustomerName",
//                data: "{'cusName':'" + document.getElementById('txtCusName').value + "'}",
//                dataType: "json",
//                success: function (data) {
//                    response(data.d);
//                },
//                error: function (result) {
//                    alert("No Match");
//                }
//            })
//        }
//    })
//}
