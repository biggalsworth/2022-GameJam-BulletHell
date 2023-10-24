using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats instance;
    public GameObject PlayerSpriteOwner;

    public float DamageCooldown = 0.75f;

    [Header("Player Stats")]
    public float health;
    public float maxHealth = 100;

    //This will control if the player is invincible
    //after being hit
    public bool invul;

    //This will make sure the normal attack increases its damage if we get a damage increase item
    public static int damageIncrease;


    [Header("Player Stats Display")]
    public Slider slider;
    public GameObject sliderColour;

    // Start is called before the first frame update
    void Start()
    {
        damageIncrease = 0;

        invul = false;
        instance = this;
        health = maxHealth;
        slider.maxValue = maxHealth;
        slider.value = health;
    }

    // Update is called once per frame
    void Update()
    {
        if(slider.value != health)
        {
            slider.value = health;
        }

        if (health <= 0)
        {
            Die();
        }
    }

    public void GainHealth(int gain)
    {
        if(health < maxHealth)
        {
            health += gain;

            if (health > maxHealth)
            {
                health = maxHealth;
            }
        }
    }

    public void LoseHealth(int loss)
    {
        if (!invul)
        {
            health -= loss;
            if (health <= 0)
            {
                health = 0;
            }
            else if (health >= 0)
            {
                StartCoroutine(invulFrames());
            }
        }
    }

    private IEnumerator invulFrames()
    {
        invul = true;

        BoxCollider2D coll = gameObject.GetComponent<BoxCollider2D>();
        //coll.isTrigger = true;

        Animator anim = GetComponent<Animator>();
        anim.Play("Pain");

        yield return new WaitForSeconds(DamageCooldown);

        invul = false;
        //coll.isTrigger = false;
    }


    public void Die()
    {
        sliderColour.SetActive(false);
    }
}
