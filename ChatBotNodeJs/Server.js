//Websocket Ways
var websocket = require ('ws');

//Port Sever
var websocketServer = new websocket.Server ({port:45544}, ()=>{

    // status Sever
    console.log("BB IS ONLINE")
} )

//Number Member List On Sever
var wsList = [];


// When Client Connected
websocketServer.on("connection", (ws,rq)=>{
    //print status server
    console.log ("client connected.")

    // Add List On server
    wsList.push(ws);

    //Boardcast Message
    ws.on ("message",(data)=>{

         
        console.log("Sent from client : "+data )
        Boardcast(data,ws);


    })

    //Client Disconnected
    ws.on("close",()=>{

       wsList = ArrayRemove(wsList,ws);
        console.log("client Disconnected")
    })

} ) 

//Remove Member List On  server
function ArrayRemove(arr,value){
    return arr.filter ((element)=>{
        return element != value
    })
}

//Boardcast to all member in server
function Boardcast(data,ws)
{
    
    for(var i = 0 ; i <wsList.length ; i++)
    {  
        if (wsList[i] != ws)
        {
            wsList[i].send(data);
        }

  
    }
}