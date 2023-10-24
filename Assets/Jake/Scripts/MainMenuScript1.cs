using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript1 : MonoBehaviour

{
    public GameObject settings;
    public GameObject credits;
    
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //This is the Quit Function which is Public so we can use it within any Game Component
    public void QuitButton()
    {
        Debug.Log("Quitting Game..."); //This writes "Quitting Game..." in the Console when the Quit Button is pressed
        Application.Quit(); //This will Quit the Application when the button is pressed
    }

    //This is the Play Function which is Public so we can use it within any Game Component
    public void PlayButton()
    {
        Debug.Log("Game Started..."); //This writes "Game Started..." in the Console when the Play Button is pressed
        SceneManager.LoadScene(1); //This will change the scene to the scene where the game takes place
        

    }

    //This is the Settings Function which is Public so we can use it within any Game Component
    public void SettingsButton()
    {
        settings.SetActive(true);
        /*
        Debug.Log("Settings Loading..."); //This writes "Settings Loaded...." in the Console when the Settings Button is pressed
        SceneManager.LoadScene("SettingsMenu"); //This will change the scene to the "Settings" scene where the settings are located*/
    }


    public void Tutorial()
    {
        //scene 2 is the tutorial
        SceneManager.LoadScene(2);
    }


    public void showCredits()
    {
        credits.SetActive(true);
    }
    
    public void HideCredits()
    {
        credits.SetActive(false);
    }



    //This is the Back Function which is Public so we can use it within any Game Component
    public void BackButton()
    {
        Debug.Log("Switching To Main Menu..."); //This writes "Switching To Main Menu..." in the Console when the Back Button is pressed
        SceneManager.LoadScene("MainMenu"); //This will change the scene back to the "Main Menu" scene (The Back Button is located in the Settings Menu)
    }

   
}
