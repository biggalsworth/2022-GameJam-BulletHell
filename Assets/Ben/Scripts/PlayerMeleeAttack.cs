using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMeleeAttack : MonoBehaviour
{
    public int damage = 3;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("aHHH");
        GameObject hit = other.gameObject;
        if (hit.tag == "Enemy")
        {
            hit.GetComponent<Enemy_Stats>().TakeDamage(damage += PlayerStats.damageIncrease);
        }
    }
}
