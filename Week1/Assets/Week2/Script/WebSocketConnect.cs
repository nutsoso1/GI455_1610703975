using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebSocketSharp;




namespace Programchat
{

    public class WebSocketConnect : MonoBehaviour
    {
        private WebSocket webSocket;

        // Start is called before the first frame update
        void Start()
        {
            webSocket = new WebSocket("ws://127.0.0.1:25500/");

            webSocket.OnMessage += OnMessage;

            webSocket.Connect();
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                webSocket.Send("Number : " + Random.Range(0, 99999));
            }
        }

        public void OnDestroy()
        {
            if (webSocket != null)
            {
                webSocket.Close();
            }
        }

        public void OnMessage(object sender, MessageEventArgs messageEventArgs)
        {
            Debug.Log("Message from sever : " + messageEventArgs.Data);
        }
    }

}




