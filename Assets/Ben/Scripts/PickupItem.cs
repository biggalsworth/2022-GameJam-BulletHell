using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour
{
    public GameObject PickupEffect = null;

    [Header("Stat boost choice")]
    public bool healthInc;
    public bool maxHealthInc;
    public bool speedInc;
    public bool attackInc;

    [Header("How much to increase that stat by")]
    public int increaseAmount;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject obj = collision.gameObject;

        if (obj.tag == "Player")
        {
            if (healthInc)
            {
                PlayerStats.instance.GainHealth(increaseAmount);
            }
            else if (maxHealthInc)
            {
                PlayerStats.instance.maxHealth += increaseAmount;
            }
            else if (speedInc)
            {
                playerMovement.instance.moveSpeed += increaseAmount;
            }
            else if (attackInc)
            {
                PlayerStats.damageIncrease += increaseAmount;
            }
            increaseAmount = 0;
            

            if(PickupEffect != null)
            {
                Instantiate(PickupEffect, transform.position, Quaternion.identity);
            }

            Destroy(gameObject);
        }
    }
}
