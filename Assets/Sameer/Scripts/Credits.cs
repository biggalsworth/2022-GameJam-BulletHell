using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Credits : MonoBehaviour
{

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CreditsButton()
    {
        Debug.Log("Loading Up The Credits Scene..");
        SceneManager.LoadScene("CreditsMenu");
    }

   
}
