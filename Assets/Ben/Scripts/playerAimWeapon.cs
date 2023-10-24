using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAimWeapon : MonoBehaviour
{
    //Variables
    Vector3 mousePos;
    private Transform aimPos;

    // Start is called before the first frame update
    void Start()
    {
        //Get the game object responsible for the shooting direction
        aimPos = GameObject.Find("shootPoint").transform;
    }

    // Update is called once per frame
    void Update()
    {
        //This will make sure the player can aim at a specific point

        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //Now we have the mouse position, we shall aim towards it.
        Vector3 aimDir = (mousePos - transform.position).normalized; 
        // now we need to only get the z angle and make set the aiming towards that point 
        float angle  = Mathf.Atan2(aimDir.y, aimDir.x) * Mathf.Rad2Deg;
        aimPos.eulerAngles = new Vector3(0, 0, angle);

    }
}
