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
                    window.location.href = "/Home/Dashboard?userId=" + user_id;
                }
                else {
                }
            }
        });
    }

    var likeTrit = function (userId, tritId, i) {
        TP.Data.PostData({
            Url: '/Home/LikeTrit',
            Data: { userId: userId, tritId: tritId },
            Async: false,
            LoadingHideTimeout: 1000,
            SuccessFunc: function (result) {
                console.log(result.content);
                if (result.isSuccess) {
                    $("#likeButton-" + i).css('color', 'red');
                }
                else {
                }
            }
        });
    }


    var searchUser = function (userId, word) {
        TP.Data.GetData({
            Url: '/Home/SearchUser',
            Data: { userId: userId, word: word },
            Async: false,
            LoadingHideTimeout: 1000,
            SuccessFunc: function (result) {
                console.log(result);
                if (result.isSuccess) {
                    window.location.href = "/Home/Search?userId=" + userId;
                }
                else {
                }
            }
        });
    }

    return {
        CheckUserLogin: checkUserLogin,
        GetTrits: getTrits,
        SendTritToDB: sendTritToDB,
        LikeTrit: likeTrit,
        SearchUser: searchUser

    };
}());