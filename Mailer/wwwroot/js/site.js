
let previousReceiver = null;
let dateTimeReceiver = new Date();
let dateTimeUser = new Date();
let userName = getCookie("Name") ?? null;

function getUserMessages(user, time, url, selector) {
    $.ajax({
        url: url,
        method: 'post',
        dataType: 'html',
        data: { User: user, Time: time.toJSON() },
        success: function (data) {
            if (data !== '')
                $(selector).append(data);
        }
    });

}

function OnSuccessSendMessage(){
    let newReceiver = $('#Receiver').val();
    let title = $('#Title').val();
    let body = $('#Body').val();
    if (newReceiver === '' || title === '' || body === '')
        return;
    if (previousReceiver !== newReceiver) {
        previousReceiver = newReceiver;
        dateTimeReceiver = new Date(0);
        $('#receiver-wrapper').children().remove();
    }
    getUserMessages(newReceiver, dateTimeReceiver, '/Message/DisplayReceiverMessages/', '#receiver-wrapper');
    dateTimeReceiver = new Date();
}

function getCookie(name) {
    const value = `; ${document.cookie}`;
    const parts = value.split(`; ${name}=`);
    if (parts.length === 2) return parts.pop().split(';').shift();
}

if (userName !== null) {
    const timeInterval = 5000;
    $('#account-user').text(userName);
    setTimeout(() => getUserMessages(userName, new Date(0), '/Message/DisplayReceiverMessages/', '#user-wrapper'));
    setInterval(() => { getUserMessages(userName, dateTimeUser, '/Message/DisplayReceiverMessages/', '#user-wrapper'); dateTimeUser = new Date(); }, timeInterval);
}


