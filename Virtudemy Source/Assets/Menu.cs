using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class Menu : MonoBehaviour {
	public GameObject username;
	public GameObject password;


	private string Username;
	private string Password;
	private string DecryptedPass;
	private string[] Lines;


    private bool InvalidPass = false;
    private bool IncorrectPass = false;
    private bool InvalidUser = false;



	public void LoginButton(){
		bool UN = false;
		bool PW = false;


		if (Username != "") {
			if (System.IO.File.Exists (@"Assets\Data Storage" + Username+".txt")) {

                UN = true;
				Lines = System.IO.File.ReadAllLines (@"Assets\Data Storage" + Username + ".txt");
			} else {
				Debug.LogWarning ("Username Invaild");
			}
		} 
		else {
			Debug.LogWarning ("Username Field Empty");
		}


		if (Password != ""){
			if (System.IO.File.Exists(@"Assets\Data Storage" + Username+".txt"))
            {
				int i = 1;
				foreach(char c in Lines[2]){
					i++;
					char Decrypted = (char)(c / i);
					DecryptedPass += Decrypted.ToString();
				}
				if (Password == DecryptedPass){
					PW = true;
				} else {
					Debug.LogWarning("Password Is invalid");
				}
			} else {
				Debug.LogWarning("Password Is invalid");
			}
		} else {
			Debug.LogWarning("Password Field Empty");
		}
		if (UN == true&&PW == true){
			username.GetComponent<InputField>().text = "";
			password.GetComponent<InputField>().text = "";	
			print ("Login Sucessful");
			Application.LoadLevel("Prototype");
		}
	}


    void Update ()
    {
		if (Input.GetKeyDown(KeyCode.Tab))
        {
			if (username .GetComponent<InputField>().isFocused)
            {
				password .GetComponent<InputField>().Select();
			}
		}
		if (Input.GetKeyDown(KeyCode.Return))
        {
			if (Password != ""&&Password != "")
            {
				LoginButton();
			}
		}
		Username = username .GetComponent<InputField>().text;
		Password = password .GetComponent<InputField>().text;	

        //InvalidPass
        //InvalidUser
        //IncorrectPass

        if(InvalidPass==true)
        {
            IncorrectPass = false;
            InvalidUser = false;
        }

        else if(IncorrectPass==true)
        {
            InvalidPass = false;
            InvalidUser = false;
        }

        else if(InvalidUser==true)
        {
            IncorrectPass = false;
            InvalidPass = false;
        }
	}

    public void HiddenButton()
    {
        Application.LoadLevel("Tlog");
    }

    void OnGUI()
    {
        if(InvalidPass==true)
        {
            GUI.Label(new Rect(Screen.width / 2 - 75, Screen.height - 100, 150, 30), "Password field empty.");
        }

        if(IncorrectPass==true)
        {
            GUI.Label(new Rect(Screen.width / 2 - 75, Screen.height - 100, 150, 30), "Incorrect Password.");
        }

        if(InvalidUser==true)
        {
            GUI.Label(new Rect(Screen.width / 2 - 75, Screen.height - 100, 150, 30), "Invalid Username.");
        }
    }
}
