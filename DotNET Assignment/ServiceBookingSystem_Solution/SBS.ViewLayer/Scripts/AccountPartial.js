import { get } from "jquery";

$.ajax({
    cache: false,
    type: 'GET',
    url: '/Account/GetView',
    data: null,
    success: OnSuccessCall,
    error: OnErrorCall
});

var OnSuccessCall = function (response) {
    $("#content").html(response.valueOf(0))
}

var OnErrorCall = function () {
    alert(request.status + " " + request.statusText);
}