using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeShooting : MonoBehaviour
{

    public static SlimeShooting instance;


    public Transform AimPosition;

    public bool shootNow;
    public bool able_ToShoot = true;

    public float shooting_Range;
    public float shooting_Speed = 1;
    public float cool_down;
    public int damage = 0;


    public GameObject bullet;
    public GameObject bullet_pairing;

    void Start()
    {
        instance = this;
        able_ToShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (shootNow)
        {
            Shoot();
        }
    }

    
    //this shoot function will basically enable the player to fire out the bullet prefab towards the player.
    public void Shoot()
    {
        if (able_ToShoot)
        {
            GameObject Player = GameObject.FindGameObjectWithTag("Player");
            Transform PlayerPos = Player.transform;
            //aiming towards player
            Vector3 aimDir = (PlayerPos.position - transform.position).normalized;
            // now we need to only get the z angle and make set the aiming towards that point 
            float angle = Mathf.Atan2(aimDir.y, aimDir.x) * Mathf.Rad2Deg;
            AimPosition.eulerAngles = new Vector3(0, 0, angle);

            GameObject newBullet = Instantiate(bullet, transform.position, AimPosition.transform.rotation);
            newBullet.GetComponent<bullet>().speed = shooting_Speed;
            if(damage != 0)
            {
                newBullet.GetComponent<bullet>().damage = damage;
            }
            Destroy(newBullet, 5f);
            StartCoroutine(BulletChill());
        }
    }


    //this function here is used as a way to make the slime shoot slowly as apposed to firing a million bullets.
    public IEnumerator BulletChill()
    {
        able_ToShoot = false;
        yield return new WaitForSeconds(cool_down);
        able_ToShoot = true;
    }


}
