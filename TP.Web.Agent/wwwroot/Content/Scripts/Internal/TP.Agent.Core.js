

Core = (function () {

    let appProcessQueue = [];
    var init = function () { };

    var addProcessToQueue = function (func, args) {
        appProcessQueue.push([func, args]);
    };

    var runProcessesFromQueue = function () {
        var queueLength = appProcessQueue.length;
        for (let i = 0; i < queueLength; i++) {
            let func = appProcessQueue[i][0],
                args = appProcessQueue[i][1];

            if (func && jQuery.isFunction(func))
                func(args);
        }

        if (queueLength > 0)
            appProcessQueue = [];
    };

    var createTable = function (tableName) {
        $("#" + tableName).DataTable({
            responsive: !0,
            pagingType: "full_numbers",
            language: {
                lengthMenu: "Göster _MENU_",
                search: "Ara",
                info: "Toplam _TOTAL_ kayıt arasından gösterilen _START_ - _END_",
                loadingRecords: "Yükleniyor...",
                processing: "İşleniyor...",
            }
        })
    };

    var createTableInteraction = function (tableName) {
        $("#" + tableName).DataTable({
            responsive: !0,
            pagingType: "full_numbers",
            order: false,
            language: {
                lengthMenu: "Göster _MENU_",
                search: "Ara",
                info: "Toplam _TOTAL_ kayıt arasından gösterilen _START_ - _END_",
                loadingRecords: "Yükleniyor...",
                processing: "İşleniyor...",
            }
        })
    };

    var createDatepicker = function (inputName) {
        $("#" + inputName).datepicker({
            format: "dd.mm.yyyy",
            language: "tr",
            autoclose: true,
            minDate: dateToday
        });
    }

    return {
        Init: init,
        AddProcessToQueue: addProcessToQueue,
        RunProcessesFromQueue: runProcessesFromQueue,
        CreateTable: createTable,
        CreateDatepicker: createDatepicker,
        CreateTableInteraction: createTableInteraction,
    };

}());

$(document).ready(function () {
    Core.Init();
    Core.RunProcessesFromQueue();
});