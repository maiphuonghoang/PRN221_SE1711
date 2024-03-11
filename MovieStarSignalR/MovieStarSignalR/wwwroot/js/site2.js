

var connection = new signalR.HubConnectionBuilder()
    .withUrl("/SignalRServer")
    .build();


connection.start().catch(function (err) {
    return console.error(err.toString());
});
const inputElement = document.getElementById("searchText");
inputElement.addEventListener('focus', () => {
    console.log("Đang nhập");
    connection.invoke("OpenChat")
})
inputElement.addEventListener('input', () => {
    console.log("Nội dung của input file ", inputElement.value);
    connection.invoke("DoingChat", inputElement.value)
})
inputElement.addEventListener('blur', () => {
    console.log("Ngừng nhập ", inputElement.value);
    connection.invoke("CloseChat")
})

connection.on("OpenChatResult", (x) => {
    const resultChat = document.getElementById('resultChat');
    resultChat.innerHTML = 'user open search'
})
connection.on("DoingChatResult", (x) => {

        const resultChat = document.getElementById('resultChat');
        resultChat.innerHTML = 'user doing searched: ' + x;
   

})
connection.on("CloseChatResult", (x) => {
    const resultChat = document.getElementById('resultChat');
    resultChat.innerHTML = 'user has stopped search'
})
