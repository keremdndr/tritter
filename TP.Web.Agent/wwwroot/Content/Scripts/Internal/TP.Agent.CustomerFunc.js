function sendTrit(user_id) {
    var trit = $("#newTrit").val();
    console.log(user_id)
    TP.Customer.SendTritToDB(user_id, trit)
}