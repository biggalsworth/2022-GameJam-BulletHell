using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour
{
    public int damage = 3;
    public int speed = 7;
    private float rotCount = 0;

    private GameObject target;

    public GameObject magicBallSkin;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //calculate direction
        Rigidbody2D bulletBody = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");
        Vector2 targetDir = (target.transform.position - transform.position).normalized * speed;

        //add force towards target
        bulletBody.velocity = new Vector2(targetDir.x, targetDir.y);

        //Spin the sprite
        rotCount += 5f;
        magicBallSkin.transform.Rotate(0, 0, rotCount * Time.deltaTime);
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (col.GetComponent<PlayerStats>().invul == false)
            {
                col.GetComponent<PlayerStats>().LoseHealth(damage);
                Destroy(gameObject);
            }
        }
    }
}
