using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public static playerMovement instance;

    [Header("Components")]
    public Rigidbody2D rb;

    [Header("Movement")]
    public float moveSpeed = 3f;
    private Vector2 movement;

    public SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        rb.velocity = movement * moveSpeed;

        if(PlayerStats.instance.invul == false)
        {
            if(rb.velocity != Vector2.zero)
            {
                gameObject.GetComponent<Animator>().Play("PlayerMove");
            }
            else
            {
                gameObject.GetComponent<Animator>().Play("Idle");
            }


            if (rb.velocity.x < 0)
            {
                sprite.flipX = true;
            }
            else if(rb.velocity.x > 0)
            {
                sprite.flipX = false;
            }

        }

    }
}
