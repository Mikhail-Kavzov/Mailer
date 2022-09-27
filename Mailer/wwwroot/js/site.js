
let previousReceiver = null;
let dateTimeReceiver = new Date();
let dateTimeUser = new Date();
let userName = $('#SenderId').val() ?? null;
let userList = new Array();
function getUserMessages(user, time, url, selector) {
    $.ajax({
        url: url,
        method: 'post',
        dataType: 'html',
        data: { User: user, Time: time.toJSON() },
        success: function (data) {
            if (data !== '') {
                $(selector).append(data);
                $(selector).children().children('.message-title').each(function () {
                    $(this).click(() => $(this).next().toggleClass('msg-block-display'));
                });
            }
        }
    });
}

function OnSuccessSendMessage() {
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
    $('#receiver-user').text(newReceiver + ' messages:');
    dateTimeReceiver = new Date();
}

if (userName !== null) {
    const timeInterval = 5000;
    $('#account-user').text(userName);
    setTimeout(() => getUserMessages(userName, new Date(0), '/Message/DisplayReceiverMessages/', '#user-wrapper'));
    setInterval(() => { getUserMessages(userName, dateTimeUser, '/Message/DisplayReceiverMessages/', '#user-wrapper'); dateTimeUser = new Date(); }, timeInterval);
    setTimeout(() => updateUserList('/User/GetUsers/'));
    const userInterval = 20000;
    setInterval(() => updateUserList('/User/GetUsers/'), userInterval);
}

function updateUserList(url) {
    $.ajax({
        url: url,
        method: 'post',
        dataType: 'json',
        success: function (data) {
            if (data !== '') {
                userList = data;
            }
        }
    });
}
function appendDropdown(list) {
    if (list.length === 0)
        return;
    $.each(list, function (key, value) {
        let element = $("<li></li>").text(value);
        $('#dropdown').append(element);
    });
    $('#dropdown').children().each(function () { $(this).click(() => { $('#Receiver').val($(this).text()); $('#dropdown').children().remove(); }); });
}
$('#Receiver').keyup(function () {
    $('#dropdown').children().remove();
    let textVal = $('#Receiver').val();
    if (textVal === '')
        return;
    let newList = new Array();
    $.each(userList, function (key, value) {
        if (value.startsWith(textVal))
            newList.push(value);
    });
    appendDropdown(newList);
});

$(document).mouseup(function (e) {
    let element = $("#receiver-container");
    if (!element.is(e.target) && element.has(e.target).length === 0)
        $('#dropdown').hide();
    else
        $('#dropdown').show();
});