using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UiManager : MonoBehaviour
{
    public static UiManager instance;

    [Header("Pause Screen")]
    public GameObject PauseMenu;
    public bool paused;

    [Header("Respawn Screen")]
    public GameObject RespawnUI;


    // Start is called before the first frame update
    void Start()
    {
        RespawnScreen();

        paused = false;

        instance = this;

    }

    // Update is called once per frame
    void Update()
    {
        CheckInputs();
    }

    void CheckInputs()
    {

        //Pause Managing
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!paused)
            {
                Pause();
            }
            else
            {
                UnPause();
            }
        }
    }

    #region PauseMenu
    public void Pause()
    {
        paused=true;
        PauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void UnPause()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1f;
        paused = false;
    }
    #endregion



    #region Respawn Menu

    public void RespawnScreen()
    {
        RespawnUI.SetActive(true);
    }

    #endregion
}
