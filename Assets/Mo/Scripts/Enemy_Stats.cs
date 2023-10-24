
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Stats : MonoBehaviour
{
    public float MaxHealth = 10f;
    public float Health;

    public bool deathAnim = false;
    private bool playingDeath = false;
    public string deathAnimName;
    // Start is called before the first frame update
    void Start()
    {
        Health = MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        //make sure it doesnt keep dying as the death animation plays
        if(Health <= 0 && !playingDeath)
        {
            Die();
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject obj = collision.gameObject;

        if (obj.tag == "PlayerAttack")
        {
            //All damage is now handled inside the bullet


            //float damage = obj.GetComponent<PlayerBullet>().damage;
            //TakeDamage(obj.GetComponent<PlayerBullet>().damage);
            Destroy(obj);
        }
    }

    public void TakeDamage(float damage)
    {
        Health -= damage;
    }


    void Die()
    {
        if (deathAnim)
        {
            playingDeath = true;

            //Stop the enemy from moving
            
            if (gameObject.name.ToLower().Contains("slime"))
            {
                gameObject.GetComponent<SlimeShooting>().enabled = false;
                gameObject.GetComponent<SlimeEnemy>().enabled = false;
            }
            else if (gameObject.name.ToLower().Contains("skel"))
            {
                gameObject.GetComponent<SkeletonMovement>().enabled = false;
            }

            gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;


            gameObject.GetComponent<Animator>().Play(deathAnimName);
            Destroy(gameObject, 1f);

        }

        gameObject.GetComponent<EnemyDrop>().DropLoot();

        if (!deathAnim)
        {
            Destroy(gameObject);
        }
        KillCounter.Instance.CounterIncrease();
    }

}
