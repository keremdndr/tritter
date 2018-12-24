TP.Ui = (function () {
  
    //#region Loading

    var loadingManager = function (options) {
        $('body').modalmanager(options);
    },
        setLoadingOptions = function () {
            $.fn.modalmanager.defaults.spinner = '<div class="loading-spinner modal-loading fade"></div>';
        },
        showInsideLoading = function (container) {
            var hasLoading = $(container).find('.insideLoading').length > 0;
            if (!hasLoading)
                $(container).prepend('<div class="insideLoading"><div class="img"></div></div>');
        },
        hideInsideLoading = function (container) {
            var loading = $(container).find('.insideLoading');
            if (loading.length > 0)
                loading.remove();
        },
        showFullScreenLoading = function () {
            loadingManager('loading');
        },
        hideFullScreenLoading = function () {
            setTimeout(function () {
                loadingManager('removeLoading');
            }, 500);
        };

    //#endregion
 
    

    //#region Public members

    return {
                  
        ShowFullPageLoading: showFullScreenLoading,
        ShowInsideLoading: showInsideLoading,
        HideInsideLoading: hideInsideLoading,
        HideFullScreenLoading: hideFullScreenLoading
    };

    //#endregion

}());
