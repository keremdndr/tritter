TP.Home = (function () {

    var getCampaignList = function (campaignId) {
        TP.Data.GetData({
            Url: '/Home/GetCampaignPreviewList',
            Data: { campaignId: campaignId },
            Async: false,
            LoadingHideTimeout: 1000,
            SuccessFunc: function (result) {
                console.log(result.isSuccess);
                if (result.isSuccess) {
                    console.log(result);

                    $('#CampaignListList')
                        .find('option')
                        .remove()
                        .end()
                        .append(new Option("Kampanya Listesi Seçiniz", ""));
                        
                    for (var i = 0; i < result.data.length; i++) {
                        $("#CampaignListList").append(new Option(result.data[i].name, result.data[i].id));
                    }
                   
                }
                else {
                    // 
                }
            }
        });
    }

    var getCustomerByCampaignList = function (campaignId , campaignListId) {
        TP.Data.GetData({
            Url: '/Home/GetCustomerByCampaignList',
            Data: { campaignId: campaignId, campaignListId: campaignListId },
            Async: false,
            LoadingHideTimeout: 1000,
            SuccessFunc: function (result) {
                console.log(result.isSuccess);
                if (result.isSuccess) {
                    console.log(result);
                    $("#CustomerList").html(result.content);
                    $("#CampaignId").val(campaignId);
                }
                else {
                    // 
                }
            }
        });
    }

    var getCustomerByPhone = function (campaignId, campaignListId, customerPhone) {
        TP.Data.GetData({
            Url: '/Home/GetCustomerByPhone',
            Data: { campaignId: campaignId,  campaignListId: campaignListId, customerPhone: customerPhone },
            Async: false,
            LoadingHideTimeout: 1000,
            SuccessFunc: function (result) {
                console.log(result.isSuccess);
                if (result.isSuccess) {
                    console.log(result);
                    $("#CustomerList").html(result.content);
                    $("#CampaignId").val(campaignId);
                }
                else {
                    // 
                }
            }
        });
    }

    var getCustomerByCustomerNo = function (campaignId, campaignListId, customerNo) {
        TP.Data.GetData({
            Url: '/Home/GetCustomerByCustomerNo',
            Data: { campaignId: campaignId,  campaignListId: campaignListId, customerNo: customerNo },
            Async: false,
            LoadingHideTimeout: 1000,
            SuccessFunc: function (result) {
                console.log(result.isSuccess);
                if (result.isSuccess) {
                    console.log(result);
                    $("#CustomerList").html(result.content);
                    $("#CampaignId").val(campaignId);
                }
                else {
                    // 
                }
            }
        });
    }

    var getAllCustomer = function () {
        TP.Data.GetData({
            Url: '/Home/GetAllCustomer',
            Data: {  },
            Async: false,
            LoadingHideTimeout: 1000,
            SuccessFunc: function (result) {
                console.log(result.isSuccess);
                if (result.isSuccess) {
                    console.log(result);
                    $("#CustomerList").html(result.content);

                }
                else {
                    // 
                }
            }
        });
    }



    return {
        GetCampaignList: getCampaignList,
        GetCustomerByCampaignList: getCustomerByCampaignList,
        GetCustomerByPhone: getCustomerByPhone,
        GetCustomerByCustomerNo: getCustomerByCustomerNo,
        GetAllCustomer: getAllCustomer
    };
}())

//$(document).ready(function () {
//    $('#customerTable tr').dblclick(function () {
//        window.location = '/Customer/Index?customerId=' + $(this).data('id')
//    });
//});
