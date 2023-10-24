using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossStats : MonoBehaviour
{
    public float maxHealth;
    public float health;

    public GameObject EndGameUI;

    [Header("Slider")]
    public Slider healthSlider;
    public GameObject slider;

    // Start is called before the first frame update
    void Start()
    {
        //Get the sliders
        slider = GameObject.Find("BossHealth");
        healthSlider = GameObject.Find("BossHealthSlider").GetComponent<Slider>();

        slider.SetActive(true);
        health = maxHealth;
        healthSlider.maxValue = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
        healthSlider.value = health;
        if(health <= 0)
        {
            health = 0;
            BossDeath();
        }
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject obj = collision.gameObject;

        //validates if the object is the players attack
        if (obj.tag == "PlayerAttack")
        {
            //take the damage and destroy the bullet
            TakeDamage(obj);
            Destroy(obj);
        }
    }


    public void TakeDamage(GameObject bullet)
    {
        float damage = bullet.GetComponent<PlayerBullet>().damage += PlayerStats.damageIncrease;

        health -= damage;
    }


    public void BossDeath()
    {
        Destroy(gameObject);

        //Load a UI that allows the user to leave.
        EndGameUI.SetActive(true);

        Cursor.visible = true;

        GameObject.Find("aimPoint").SetActive(false);

        Time.timeScale = 0f;
    }
}
