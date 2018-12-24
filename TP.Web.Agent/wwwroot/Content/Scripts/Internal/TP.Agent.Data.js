TP.Data = (function () {
    //#region Constants

    var jscrollAdditionalDataKey = 'jscrollAdditionalData',
        loadingTimeout = 500,
        canShowLoading = false;


    //#endregion
     

    //#region Ajax Requests

    var getAjaxRequestOptions = function (options) {
        return {
            InitPlugins: options && IsNotNullOrUndefined(options.InitPlugins) ? options.InitPlugins : true,
            ShowLoading: options && IsNotNullOrUndefined(options.ShowLoading) ? options.ShowLoading : true,
            LoadingContainer: options && IsNotNullOrUndefined(options.LoadingContainer) ? options.LoadingContainer : '',
            HideLoadingOnSuccess: options && IsNotNullOrUndefined(options.HideLoadingOnSuccess) ? options.HideLoadingOnSuccess : true,
            Url: options && options.Url ? options.Url : '',
            Data: options && options.Data ? options.Data : '',
            Cache: options && IsNotNullOrUndefined(options.Cache) ? options.Cache : false,
            Traditional: options && IsNotNullOrUndefined(options.Traditional) ? options.Traditional : false,
            Async: options && IsNotNullOrUndefined(options.Async) ? options.Async : true,
            SuccessFunc: options && IsNotNullOrUndefined(typeof (options.SuccessFunc)) && jQuery.isFunction(options.SuccessFunc) ? options.SuccessFunc : null,
            ErrorFunc: options && IsNotNullOrUndefined(typeof (options.ErrorFunc)) && jQuery.isFunction(options.ErrorFunc) ? options.ErrorFunc : null,
            BeforeSendFunc: options && IsNotNullOrUndefined(typeof (options.BeforeSendFunc)) && jQuery.isFunction(options.BeforeSendFunc) ? options.BeforeSendFunc : null,
            CompleteFunc: options && IsNotNullOrUndefined(typeof (options.CompleteFunc)) && jQuery.isFunction(options.CompleteFunc) ? options.CompleteFunc : null,
            LoadingHideTimeout: options && options.LoadingHideTimeout ? options.LoadingHideTimeout : 0
        };
    },
        getData = function (requestOptions) {
            var options = getAjaxRequestOptions(requestOptions);

            if (!options.Async) {
                if (options.ShowLoading) {
                    canShowLoading = true;
                    setTimeout(function () {
                        if (options.LoadingContainer) {
                            //TP.UiShowInsideLoading(options.LoadingContainer);
                        }
                       // else
                            //TP.UiShowFullPageLoading();
                    }, 0);
                }
            }
            $.ajax({
                url: options.Url,
                data: options.Data,
                type: 'POST',
                cache: options.Cache,
                traditional: options.Traditional,
                async: options.Async,
                beforeSend: function () {
                    if (options.ShowLoading) {
                        canShowLoading = true;
                        setTimeout(function () {
                            if (canShowLoading) {
                                if (options.LoadingContainer) {
                                    //TP.UiShowInsideLoading(options.LoadingContainer);
                                }
                               // else
                                    //TP.UiShowFullPageLoading();
                            }
                        }, loadingTimeout);
                    }

                    if (options.BeforeSendFunc)
                        options.BeforeSendFunc();
                },
                error: function (xhr, ajaxOptions, thrownError) {
                    canShowLoading = false;
                    if (options.ShowLoading) {
                       // if (options.LoadingContainer)
                            //TP.UiHideInsideLoading(options.LoadingContainer);
                        //else
                            //TP.UiHideFullScreenLoading();
                    }

                    if (options.ErrorFunc)
                        options.ErrorFunc();
                    //else
                        //TP.UiNotify(//TP.UiNotifyType.Error, 'Hata', AppendFormat('İşlem isteği sırasında hata oluştu.<br/>İstek adresi: "{0}"', [options.Url]));
                },
                complete: function () {
                    if (options.CompleteFunc)
                        options.CompleteFunc();
                },
                success: function (result) {
                    canShowLoading = false;
                    setTimeout(function () {
                        if (options.HideLoadingOnSuccess) {
                           // if (options.LoadingContainer)
                                //TP.UiHideInsideLoading(options.LoadingContainer);
                           // else
                                //TP.UiHideFullScreenLoading();
                        }
                    }, options.LoadingHideTimeout);


                    if (options.SuccessFunc) {
                        options.SuccessFunc(result);

                        //if (options.InitPlugins)
                            //TP.Agent.Core.InitPlugins();
                    }
                }
            });
        },
        postData = function (requestOptions) {
            var options = getAjaxRequestOptions(requestOptions);
            if (!options.Async) {
                if (options.ShowLoading) {
                    canShowLoading = true;
                    setTimeout(function () {
                        if (options.LoadingContainer) {
                            //TP.UiShowInsideLoading(options.LoadingContainer);
                        }
                       // else
                            //TP.UiShowFullPageLoading();
                    }, 0);
                }
            }
            $.ajax({
                url: options.Url,
                data: options.Data,
                dataType: 'json',
                contentType: options.Traditional ? 'application/json; charset=UTF-8' : 'application/x-www-form-urlencoded; charset=UTF-8',
                type: 'POST',
                cache: options.Cache,
                traditional: options.Traditional,
                async: options.Async,
                beforeSend: function () {
                    if (options.ShowLoading) {
                        canShowLoading = true;
                        setTimeout(function () {
                            if (canShowLoading) {
                                //if (options.LoadingContainer)
                                    //TP.UiShowInsideLoading(options.LoadingContainer);
                               // else
                                    //TP.UiShowFullPageLoading();
                            }
                        }, loadingTimeout);
                    }

                    if (options.BeforeSendFunc)
                        options.BeforeSendFunc();
                },
                error: function (xhr, ajaxOptions, thrownError) {
                    canShowLoading = false;
                    if (options.ShowLoading) {
                        //if (options.LoadingContainer)
                            //TP.UiHideInsideLoading(options.LoadingContainer);
                        //else
                            //TP.UiHideFullScreenLoading();
                    }

                    if (options.ErrorFunc)
                        options.ErrorFunc();
                   // else
                        //TP.UiNotify(//TP.UiNotifyType.Error, 'Hata', AppendFormat('İşlem isteği sırasında hata oluştu.<br/>İstek adresi: "{0}"', [options.Url]));
                },
                complete: function () {
                    if (options.CompleteFunc)
                        options.CompleteFunc();
                },
                success: function (result) {
                    canShowLoading = false;
                    setTimeout(function () {
                        if (options.HideLoadingOnSuccess) {
                            //if (options.LoadingContainer)
                                //TP.UiHideInsideLoading(options.LoadingContainer);
                           // else
                                //TP.UiHideFullScreenLoading();
                        }
                    }, options.LoadingHideTimeout);


                    if (options.SuccessFunc)
                        options.SuccessFunc(result);
                }
            });
        };

    //#endregion

     


    //#region Public members

    return {
        GetData: getData,
        PostData: postData        
    };

    //#endregion

}());


 
