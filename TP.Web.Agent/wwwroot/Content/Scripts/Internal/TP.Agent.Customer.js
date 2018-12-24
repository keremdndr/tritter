TP.Customer = (function () {
    var checkUserLogin = function (username, password) {
        TP.Data.GetData({
            Url: '/Home/CheckUserLogin',
            Data: { username: username, password: password },
            Async: false,
            LoadingHideTimeout: 1000,
            SuccessFunc: function (result) {
                console.log(result);
                if (result.isSuccess) {
                    window.location = "Home/Dashboard?userId=" + result.content;
                }
                else {
                    $("#cannotLogin").html("Giriş başarısız.")
                }
            }
        });
    }

    var getTrits = function (user_id) {
        TP.Data.GetData({
            Url: '/Home/GetTritsOfOthers',
            Data: { user_id: user_id },
            Async: false,
            LoadingHideTimeout: 1000,
            SuccessFunc: function (result) {
                console.log(result);
                if (result.isSuccess) {
                    $("#_PartialTrits").html(result.content);
                }
                else {
                }
            }
        });
    }

    var sendTritToDB = function (user_id, trit) {
        TP.Data.PostData({
            Url: '/Home/SendTritToDB',
            Data: { user_id: user_id, trit: trit },
            Async: false,
            LoadingHideTimeout: 1000,
            SuccessFunc: function (result) {
                console.log(result.content);
                if (result.isSuccess) {
                }
                else {
                }
            }
        });
    }


    //var getLastCallIdForPaymentPromise = function (customerId, strProductId, productType, paymentPromiseDate, detail, productNo) {
    //    TP.Data.GetData({
    //        Url: '/Customer/GetLastCallId',
    //        Data: { customerId: customerId, strProductId: strProductId, productType: productType, paymentPromiseDate: paymentPromiseDate, detail: detail, productNo: productNo },
    //        Async: false,
    //        LoadingHideTimeout: 1000,
    //        SuccessFunc: function (result) {
    //            console.log(result);
    //            if (result.isSuccess) {
    //                var lastCallId = result.data;
    //                var resultCodeList = document.getElementById("resultCodeList");
    //                if (resultCodeList != null) {
    //                    var resultCodeListText = resultCodeList.options[resultCodeList.selectedIndex].text;
    //                } else {
    //                    var resultCodeListPredictive = document.getElementById("resultCodeListPredictive");
    //                    console.log(resultCodeListPredictive);
    //                    var resultCodeListText = resultCodeListPredictive.options[resultCodeListPredictive.selectedIndex].text;
    //                }

    //                TP.Customer.SendPaymentPromise(lastCallId, customerId, resultCodeListText, strProductId, paymentPromiseDate, productType, productNo, detail);
    //            }
    //            else {
    //                //TODO
    //            }
    //        }
    //    });
    //}

    //var sendResultCode = function (customerId, lastCallId, resultCodeListText, resultCodeCode, dialedPhone, scheduledDate) {
    //    TP.Data.PostData({
    //        Url: '/Customer/SendResultCode',
    //        Data: { customerId: customerId, lastCallId: lastCallId, resultCodeListText: resultCodeListText, resultCodeCode: resultCodeCode },
    //        Async: false,
    //        LoadingHideTimeout: 1000,
    //        SuccessFunc: function (result) {
    //            console.log(result.content);
    //            if (result.isSuccess) {
    //                if (resultCodeCode == 9) {
    //                    PhonexSetDispositonCode2(resultCodeCode, result.content, scheduledDate, null, dialedPhone, null, null, null);
    //                    PhonexDebugPrint("Sonuc kodu gonderildi: " + result.content + " Randevu zamanı: " + scheduledDate);
    //                    console.log("Sonuc kodu gonderildi: " + result.content + " Randevu zamanı: " + scheduledDate)
    //                } else {
    //                    PhonexSetDispositonCode(resultCodeCode, result.content);
    //                    PhonexDebugPrint("Sonuc kodu gonderildi: " + result.content);
    //                    console.log("Sonuc kodu gonderildi: " + result.content)
    //                }
    //            }
    //            else {
    //            }
    //        }
    //    });
    //}

    return {
        //GetLastCallIdForPaymentPromise: getLastCallIdForPaymentPromise,
        CheckUserLogin: checkUserLogin,
        GetTrits: getTrits,
        SendTritToDB: sendTritToDB
        //SendResultCode: sendResultCode,

    };
}());