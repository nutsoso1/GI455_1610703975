using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputUser : MonoBehaviour
{
    public string userInputText;
    public int NumberStatusCase  ;
    public string[] DataSearch =   { "The Last Of Us Part II", "Ghost of Tsushima", "Final Fantasy VII Remake", "No Man's Sky", "Hades" };
    
    public GameObject inputField;
    public GameObject textDisplayUser;
    public GameObject textStatus;
   

   public void StorInput()
    {   userInputText = inputField.GetComponent<Text>().text;
        textDisplayUser.GetComponent<Text>().text = " Mygame \n\n\n " +  DataSearch[0] + " \n " + DataSearch[1] + " \n " + DataSearch[2 ]+" \n " + DataSearch[3] + " \n " + DataSearch[4];
    }
   public  void CheckText()
    {
        if (userInputText == DataSearch[0])
        {
            NumberStatusCase = 0;
        }

        else if (userInputText == DataSearch[1])
        {
            NumberStatusCase = 0;
        }

        else if (userInputText == DataSearch[2])
        {
            NumberStatusCase = 0;
        }

        else if (userInputText == DataSearch[3])
        {
            NumberStatusCase = 0;
        }

        else if (userInputText == DataSearch[4])
        {
            NumberStatusCase = 0;
        }

        else
        {
            NumberStatusCase = 1;
        }

    }

    public void textUpdate()
    {  if ( NumberStatusCase == 0)
        {
            textStatus.GetComponent<Text>().text = " Wow This Game Is Found ";
            textStatus.GetComponent<Text>().color =  Color .green ;
        }
        if (NumberStatusCase == 1 )
        {
            textStatus.GetComponent<Text>().text = " Sorry This Game Not Found";
            textStatus.GetComponent<Text>().color = Color.red ;
        }

    }

    public void runProgramGameS()
    {
        StorInput();
        CheckText();
        textUpdate();

    }

    public void Start()
    {
        
        StorInput();
    }
}
