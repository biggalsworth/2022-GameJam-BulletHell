using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost_Movement : MonoBehaviour
{
    public float moveSpeed = 3f;
    private bool move;
    private bool hittable;
    public Animator anim;
    public SpriteRenderer skin;

    public GameObject Player;

    private Vector2 lastPos;
    private Vector2 currPos;

    // Start is called before the first frame update
    void Start()
    {
        hittable = true;
        move = true;
        Player = GameObject.FindGameObjectWithTag("Player");
        currPos = transform.position;
        lastPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(move)
        {
           
            if (!hittable)
            {
                GetComponent<SpriteRenderer>().color = new Color(25, 25, 25, 0.5f);
                //only move if you are not dead
                if (gameObject.GetComponent<Enemy_Stats>().Health != 0)
                {
                    //Move towards player
                    anim.Play("walking");
                    transform.position = Vector2.MoveTowards(this.transform.position, Player.transform.position, moveSpeed * Time.deltaTime);
                    transform.rotation = Quaternion.Euler(Vector3.zero);


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
            else
            {
                if (gameObject.GetComponent<Enemy_Stats>().Health != 0)
                {
                    //Move towards player
                    anim.Play("walking");

                    Vector3 newDir = transform.position - Player.transform.position;
                    Vector2 temporaryVect = Vector2.MoveTowards(transform.position, newDir * 90f, moveSpeed * Time.deltaTime);

                    transform.position = new Vector3(temporaryVect.x, temporaryVect.y, transform.position.z);
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            move = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            move = true;
        }
    }
    
}
