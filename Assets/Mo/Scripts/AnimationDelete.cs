using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationDelete : MonoBehaviour
{
    public float delay = 0f;

    [HideInInspector]
    public int damage;

    // Use this for initialization
    void Start()
    {
        Destroy(gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + delay);
    }

    private void OnTriggerEnter2D(Collider2D collision)
{
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerStats>().LoseHealth(damage);
        }
    }
}
