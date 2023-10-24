using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    public float speed = 10f; //This declares the public speed variable so we can adjust what speed our character is moving at.
    public GameObject PlayerRight; //This calls the PlayerRight sprite so it can be used within our code.
    public GameObject PlayerLeft; //This calls the PlayerLeft sprite so it can be used within our code.
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    
    {
       
        Vector3 horizontal = new Vector3(Input.GetAxis("Horizontal"), 0.0f, 0.0f); //This adds the force onto both left and right of the game screen as we added the Horizontal into the X Axis.
        transform.position = transform.position + horizontal* speed; //This allows the character to move by multiplying the Movement (Horizontal) by the speed that we have set.

        if(horizontal.x == 1) //This is the IF statement which will be told to do something if the character moves at 1 or above.
        {
            PlayerRight.SetActive(true); //This will make the PlayerRight sprite visible if the statement becomes true.
            PlayerLeft.SetActive(false); // This will make the PlayerLeft sprite invisible if the statement becomes true.
        }
        if(horizontal.x == -1) //This is the IF statement which will be told to do something if the character moves at -1 or below.
        {
           PlayerRight.SetActive(false); //This will make the PlayerRight sprite invisible if the statement becomes true.
           PlayerLeft.SetActive(true); //This will make the PlayerLeft sprite visible if the statement becomes true.
        }
    
    }
        

}
