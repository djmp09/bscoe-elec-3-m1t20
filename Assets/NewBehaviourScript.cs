using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {

    int level;
    string theme, ans;
    enum Screen {MainMenu, Password, Win };
    Screen currentScreen = Screen.MainMenu;
    System.Random rnd = new System.Random();
    string[] pass1 = {"pasok", "suki", "bente", "trenta", "sampu"};
    string[] pass2 = {"alexan", "speaker", "isetann", "fakeid", "diploma"};
    string[] pass3 = {"jollibee", "pnrtrain", "krisping", "condotel", "chowking"};

    // Use this for initialization
    void Start () {
        ShowMainMenu();

    }
	
    void ShowMainMenu() {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("M1T20");
        Terminal.WriteLine("What would you like to hack into?");
        Terminal.WriteLine("Press 1 for the local Divisoria");
        Terminal.WriteLine("Press 2 for the police Recto");
        Terminal.WriteLine("Press 3 for the police Pureza");
        Terminal.WriteLine("Enter your selection:");
    }

    void OnUserInput(string input){
        if (input == "menu") {
            ShowMainMenu();
        } else if (input == "kyah"){
            Terminal.WriteLine("Pembarya, kyah!");
        } else if (currentScreen == Screen.MainMenu) {
            RunMainMenu(input);
        } else if (currentScreen == Screen.Password) {
            if (input == ans) {
                currentScreen = Screen.Win;
                RunWinScreen();
            }
            else {
                StartGame();
            }
        } else if (currentScreen == Screen.Win) {
            ShowMainMenu();
        }
    }

    void RunMainMenu(string input) {
        if (input == "1") {
            level = 1;
            theme = "Divisoria";
            StartGame();
        }
        else if (input == "2") {
            level = 2;
            theme = "Recto";
            StartGame();
        }
        else if (input == "3") {
            level = 3;
            theme = "Pureza";
            StartGame();
        }
        else {
            Terminal.WriteLine("Please choose a valid level");
        }
    }

    void RunWinScreen(){
        Terminal.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$_____$$$$");
        Terminal.WriteLine("$$$$_____$$$$$$$$$$$$$$$_____$$$$");
        Terminal.WriteLine("$$$$_____$$____$$$____$$_____$$$$");
        Terminal.WriteLine("$$$$_____$______$______$_____$$$$");
        Terminal.WriteLine("$$$$_____$____$$$$$$$$$$$$$$$$$$$");
        Terminal.WriteLine("$$$$_____$___$$___________$$$$$$$");
        Terminal.WriteLine("$$$$_____$__$$_______________$$$$");
        Terminal.WriteLine("$$$$__________$$_____________$$$$");
        Terminal.WriteLine("$$$$___________$$___________$$$$$");
        Terminal.WriteLine("$$$$_____________$_________$$$$$$");
        Terminal.WriteLine("$$$$$_____________________$$$$$$$");
        Terminal.WriteLine("Congratulations!!!");
    }

    // Update is called once per frame
    void StartGame () {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        Terminal.WriteLine("Level " + level + " - " + theme);
        string pass = ranpass(Random.Range(0, 4));
        Terminal.WriteLine("Enter password: " + pass);

	}

    string ranpass(int ran) {
        string pass = "";

        if (level == 1) {
            pass = pass1[ran];
        } else if (level == 2) {
            pass = pass2[ran];
        } else if (level == 3) {
            pass = pass3[ran];
        }

        ans = pass;
        pass = Shuffle(pass);
        return pass;
    }

    string Shuffle(string s)
    {
        string output = "";
        int arraysize = s.Length;
        int[] randomArray = new int[arraysize];

        for (int i = 0; i < arraysize; i++)
        {
            randomArray[i] = i;
        }

        Fisher_Yates(randomArray);

        for (int i = 0; i < arraysize; i++)
        {
            output += s[randomArray[i]];
        }

        return output;
    }

    void Fisher_Yates(int[] array)
    {
        int arraysize = array.Length;
        int random;
        int temp;

        for (int i = 0; i < arraysize; i++)
        {
            random = i + (int)(rnd.NextDouble() * (arraysize - i));

            temp = array[random];
            array[random] = array[i];
            array[i] = temp;
        }
    }
}
