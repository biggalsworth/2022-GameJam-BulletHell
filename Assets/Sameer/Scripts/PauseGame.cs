using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    public static PauseGame instance;

    public GameObject PauseMenu;
    private GameObject playerAim;
    private PlayerStats Player;

    public static bool paused;
    public bool hideCursor = true;
    private bool takeInput;

    [Header("Pause Menu management")]
    public GameObject settingPage;
    public GameObject ControlsPage;
    public GameObject AudioPage;
    public Button ControlsButton;
    public TextMeshProUGUI stats;


    /*
    [Header("Setting Menu Options")]
    public Image ChangeBackground;
    public Image NormalBackGround;
    public GameObject ControlsPage;
    public Button ControlsButton;
    public GameObject AudioPage;
    public Button AudioButton;
    */

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        paused = false;
        takeInput = true;
        //This makes stores the object that represents where the player is aiming
        playerAim = GameObject.Find("aimPoint");

        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        //checks if the user is allowed to unpause yet
        if (takeInput)
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                takeInput = false;
                if (paused == false)
                {
                    Debug.Log("Game Paused");

                    PauseMenu.SetActive(true);
                    //We deactivate the aim point so the red dot doesn't keep following the mouse after the game is paused.
                    playerAim.SetActive(false);
                    paused = true;

                    string statsInformation;
                    statsInformation = string.Format(@"Player Stats:
Health: {0}
Damage Increase: {1}

Game Stats:
Enemies Defeated: {2}
Enemies Left: {3}", Player.health, PlayerStats.damageIncrease, GameObject.Find("GameMaster").GetComponent<KillCounter>().kill_counter, GameObject.Find("GameMaster").GetComponent<KillCounter>().maxKills);


                    stats.text = statsInformation;


                    StartCoroutine(InputDelay("pause"));

                }
                else if (paused == true)
                {
                    Debug.Log("Game Unpaused");
                    Resume();
                    GameManager.instance.HideCursor();

                }
            }
        }

        if (Input.GetKeyUp(KeyCode.Escape))
        {
            takeInput = true;
        }

        //Hide the cursor when playing but display the cursor when paused
        if (hideCursor)
        {
            if (paused)
            {
                Cursor.visible = true;
            }
            else
            {
                Cursor.visible = false;
            }
        }
    }

    public void Resume()
    {
        paused = false;
        GoBackToMain();

        PauseMenu.SetActive(false);
        playerAim.SetActive(true);
        if (hideCursor)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Confined;
        }

        StartCoroutine(InputDelay("unpause"));
        //UiManager.instance.paused = false;

    }


    public void ShowOptions()
    {
        settingPage.SetActive(true);
        ControlsButton.Select();
    }


    #region Settings Pages
    public void ShowControls()
    {
        ControlsPage.SetActive(true);
        AudioPage.SetActive(false);
    }
    public void ShowAudio()
    {
        AudioPage.SetActive(true);
        ControlsPage.SetActive(false);
    }
    #endregion

    public void GoBackToMain()
    {
        settingPage.SetActive(false);
    }



    public void Quit()
    {
       
        SceneManager.LoadScene("MainMenu");
        

    }

    //creates a delay betweeen wehen the user can pause and unpause
    //Otherwise flickering might occur
    public IEnumerator InputDelay(string situation)
    {
        //make timescale 1 so the wait for seconds doesn't last forever
        Time.timeScale = 1f;

        //takeInput = false;
        //give the user some time to get there hand off the escape key
        yield return new WaitForSeconds(0.2f);

        //takeInput = true;
        
        //changes the time to 0 or 1 depending if the game should be paused or not
        //If the time scale is set to 0 before we do the WaitForSeconds, the wait will last forever
        if(situation == "pause")
        {
            Time.timeScale = 0f;
        }
        else if (situation == "unpause")
        {
            Time.timeScale = 1f;
            Cursor.visible = false;
        }
    }
}
