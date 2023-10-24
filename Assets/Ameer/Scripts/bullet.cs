using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{

    public int damage = 3;

    GameObject target;
    public float speed;
    Rigidbody2D bullet_shoot;
    Vector2 move_direction;

    // Start is called before the first frame update
    void Start()
    {
        bullet_shoot = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");
        Vector2 move_Direction = (target.transform.position - transform.position).normalized * speed;
        bullet_shoot.velocity = new Vector2(move_Direction.x, move_Direction.y);
        Destroy(this.gameObject, 4f);
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

    public void OnParticleCollision(GameObject other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (other.GetComponent<PlayerStats>().invul == false)
            {
                Debug.Log("Hit");
                other.GetComponent<PlayerStats>().LoseHealth(damage);
            }
        }
    }
}
