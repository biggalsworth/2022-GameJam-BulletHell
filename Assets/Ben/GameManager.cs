using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    public bool paused;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void HideCursor()
    {
        Cursor.visible = false;
    }
}
