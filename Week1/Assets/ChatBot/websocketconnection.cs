using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebSocketSharp;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



namespace Programchat{

    public class websocketconnection : MonoBehaviour
    {
     
        public  string nameUser, portNumber,textDisplay,textDisplayFormSever;
        public  InputField inputFieldName;
        public  InputField inputFieldPort;
        public  InputField inputFieldTextMSG;
        public  Text portNumberDisplay;
        public  Text userNameDisplay;
        public  Text mainDisplay;
        public  GameObject msgPrefap;
        public  GameObject msgMain;
        public GameObject loginPanal;
        public GameObject mainPanal;


        private WebSocket websocket;


        void Update()
        {

            // Input From User
            if (Input.GetKeyDown(KeyCode.Return))
            {
                senndMsg();
            }
        }

        public void senndMsg()
        {
            textDisplay =inputFieldTextMSG.text;
            websocket.Send(nameUser + "  : "+textDisplay );

            var prefapMsg = Instantiate(msgPrefap, msgMain.transform);
            var childMsg = prefapMsg.transform.GetChild(0);
            childMsg.GetComponent<Text>().text = ($"{nameUser}  : {textDisplay}");

        }




        //Close Client
        public void OnDestroy()
        { 
                if (websocket != null)
                {
                    websocket.Close();
                }
        
        
        }

        //OnMessage WebSocketSharp
        public void OnMessage(object sender, MessageEventArgs messageEventArgs)
        {
            Debug.Log("Massge from server  : " + messageEventArgs.Data);
            textDisplayFormSever = messageEventArgs.Data;


            var prefapMsgServer = Instantiate(msgPrefap, msgMain.transform);
            var childMsgServer = prefapMsgServer.transform.GetChild(0);

            prefapMsgServer.GetComponent<VerticalLayoutGroup>().childAlignment = TextAnchor.MiddleLeft;
            childMsgServer.GetComponent<Text>().text = messageEventArgs.Data;
            childMsgServer.GetComponent<Text>().alignment = TextAnchor.MiddleLeft;
        }

        public void StatusUpdate()
        {
            StoreNameAndPort();
            portNumberDisplay.GetComponent<Text>().text = "" + portNumber;
            userNameDisplay.GetComponent<Text>().text = "" + nameUser;
            //connet to port
            websocket = new WebSocket($"ws://127.0.0.1:{portNumber}");  //ws://127.0.0.1:45544

            //Connect To Sever
            websocket.Connect();

            //OnMessage Brocast to Sever
            websocket.OnMessage += OnMessage;

        }


        public void StoreNameAndPort()
        {
            nameUser = inputFieldName.text;
            portNumber = inputFieldPort.text;
            loginPanal.SetActive(false);
            mainPanal.SetActive(true);

        }

     


    }
}