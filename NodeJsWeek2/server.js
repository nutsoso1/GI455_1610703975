var WebSocket = require('ws');

var webSocketSever = new WebSocket.Server({port:25500},()=>
{
    console.log("BigBunny Is Online");
} );

var wsList = [];

webSocketSever.on("connection", (ws, rq)=>
{
    console.log('client connected');
    
    wsList.push(ws);

    ws.on("message",(data)=>
    {
        console.log("send from client : " + data);
        BoardCast(data);
    });

    ws.on("close", ()=>
    {
        wsList = ArrayRemove(wsList, ws);
        console.log("client disconneted");
    });
});



function ArrayRemove(arr, value)
{
    return arr.filter((element)=> 
    {
        return element != value;
    });
}

function BoardCast(data)
{
    for (var i = 0; i < wsList.length; i++) 
    {
        wsList[i].send(data);
    }
}