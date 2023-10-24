using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    public int moveSpeed;
    public int AttackDist;
    public float StopDist;
    public bool moveBack;

    private GameObject Player;

    public Animator anim;

    private Vector3 oldPos;
    private Vector3 newPos;

    // Start is called before the first frame update
    void Start()
    {
        //Finds the player that we will aim at.
        Player = GameObject.FindGameObjectWithTag("Player");

        oldPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {



        newPos = transform.position;

        if(newPos.x > oldPos.x)
        {
            //moved right
            oldPos = newPos;
            anim.Play("MovementRight");
        }
        else if(newPos.x < oldPos.x)
        {
            //moved left
            oldPos = newPos;
            anim.Play("MovementLeft");
        }
        else if(newPos == oldPos)
        {
            anim.Play("Idle");
            newPos = oldPos;
        }

        float distance = Mathf.Round(Vector2.Distance(gameObject.transform.position, Player.transform.position));


        if (StopDist > distance || moveBack == false)
        {
            //+1 gives it space to move
            //Stops the enemy from jumping between animations.
            if (distance < StopDist)
            {
                Vector3 direction = transform.position - Player.transform.position;

                //move away from player
                Vector2 tempVector2 = Vector2.MoveTowards(transform.position, direction * 1.75f, 9f * Time.deltaTime);
                transform.position = new Vector3(tempVector2.x, tempVector2.y, transform.position.z);
                transform.rotation = Quaternion.Euler(Vector3.forward);
            }
            else if (distance > StopDist)
            {
                Vector3 direction = Player.transform.position - transform.position;

                //move to player
                Vector2 tempVector2 = Vector2.MoveTowards(transform.position, Player.transform.position, moveSpeed * Time.deltaTime);
                transform.position = new Vector3(tempVector2.x, tempVector2.y, transform.position.z);
                transform.rotation = Quaternion.Euler(Vector3.forward);
            }
        }
        else
        {
            anim.Play("Idle");
        }


        if (distance <= AttackDist)
        {
            gameObject.GetComponent<bossAttacks>().allowedToAttack = true;
        }
        else
        {
            gameObject.GetComponent<bossAttacks>().allowedToAttack = false;
        }

    }

}
