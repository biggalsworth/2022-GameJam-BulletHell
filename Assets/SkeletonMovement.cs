using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonMovement : MonoBehaviour
{
    public float moveSpeed = 3f;
    public Animator anim;
    public SpriteRenderer skin;

    public GameObject Player;

    private Vector2 lastPos;
    private Vector2 currPos;
    public float minDist = 1;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        currPos = transform.position;
        lastPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(Player.transform.position, gameObject.transform.position);
        if ((distance <= minDist) == false)
        {
            //only move if you are not dead
            if (gameObject.GetComponent<Enemy_Stats>().Health != 0)
            {
                //Move towards player
                anim.Play("walking");
                transform.position = Vector2.MoveTowards(this.transform.position, Player.transform.position, moveSpeed * Time.deltaTime);
                transform.rotation = Quaternion.Euler(Vector3.forward);


                currPos = transform.position;
                if (lastPos.x > currPos.x)
                {
                    skin.flipX = true;
                }
                //if moving right, unflip sprite to right hand side
                else if (lastPos.x < currPos.x)
                {
                    skin.flipX = false;
                }
                //this will update the position to that it will flip if it moves to the right
                lastPos = transform.position;
            }
        }

    }
}
