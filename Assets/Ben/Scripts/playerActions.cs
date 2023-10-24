using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerActions : MonoBehaviour
{

    private Vector3 mousePos;

    [Header("Shooting")]
    public int shotLifeSpan;
    private bool AllowedToShoot = true;
    public float shotCooldown;
    public GameObject aimObject;
    public GameObject shootPoint;
    public GameObject bulletPrefab;


    [Header("Dashing Attack")]
    private bool dashing = false;
    private bool allowDash = true;
    public int speedBoost;
    public float DashDuration;
    public float DashCooldown;
    public GameObject playerSprite;
    public GameObject DashParticle;


    [Header("Melee Attack")]
    public GameObject Sword;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (PauseGame.paused == false)
        {
            Cursor.visible = false;
            CheckInput();
        }
        //locates the aim point to the mouse location
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 1; //Camera.main.transform.position.z + Camera.main.nearClipPlane;
        aimObject.transform.position = mousePos;

    }


    void CheckInput()
    {
        //Shoot
        if (Input.GetMouseButtonDown(0) && AllowedToShoot)
        {
            //spawn the bullet in the direction of the player aiming
            GameObject bullet = Instantiate(bulletPrefab, shootPoint.transform.position, shootPoint.transform.rotation);
            StartCoroutine(ShootDelay());
            bullet.GetComponent<PlayerBullet>().damage += PlayerStats.damageIncrease;
            Destroy(bullet, shotLifeSpan);
        }

        else if (Input.GetMouseButtonDown(1))
        {
            Swing();
        }

        if (Input.GetKeyDown(KeyCode.Space) && !dashing && allowDash)
        {
            StartCoroutine(Dash());
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        GameObject obj = other.gameObject;
        if (PlayerStats.instance.invul == false)
        {
            if (obj.tag == "Enemy")
            {
                PlayerStats.instance.LoseHealth(5);
            }
            else if (obj.tag == "EnemyBullet")
            {
                int damage = obj.GetComponent<bullet>().damage;
                PlayerStats.instance.LoseHealth(damage);
            }

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject obj = collision.gameObject;
        if (PlayerStats.instance.invul == false)
        {
            if (obj.tag == "Enemy")
            {
                PlayerStats.instance.LoseHealth(5);
            }
            else if (obj.tag == "EnemyBullet")
            {
                int damage = obj.GetComponent<bullet>().damage;
                PlayerStats.instance.LoseHealth(damage);
            }

        }
    }

    public void Swing()
    {
        GameObject PlaySword = Instantiate(Sword, shootPoint.transform);

        //PlaySword.transform.parent = gameObject.transform;

        //PlaySword.GetComponent<Animator>().Play("SwordSwing");

        Destroy(PlaySword, 0.5f);
    }

    public IEnumerator Dash()
    {
        dashing = true;

        Instantiate(DashParticle, gameObject.transform.position, Quaternion.identity);

        playerSprite.SetActive(false);

        playerMovement.instance.moveSpeed += speedBoost;

        PlayerStats.instance.invul = true;

        gameObject.tag = "Untagged";
        gameObject.layer = 2;

        //gameObject.GetComponent<BoxCollider2D>().isTrigger = true;

        //Anything that happens while dashing /\
        yield return new WaitForSeconds(DashDuration);
        //Anything that happens after dashing \/

        playerSprite.SetActive(true);


        playerMovement.instance.moveSpeed -= speedBoost;

        PlayerStats.instance.invul = false;

        gameObject.tag = "Player";
        gameObject.layer = 0;

        //gameObject.GetComponent<BoxCollider2D>().isTrigger = false;

        dashing = false;

        Instantiate(DashParticle, gameObject.transform.position, Quaternion.identity);


        //make sure there is a delay until when the player can dash again
        allowDash = false;

        yield return new WaitForSeconds(DashCooldown);

        allowDash = true;
    }


    public IEnumerator ShootDelay()
    {
        AllowedToShoot = false;

        yield return new WaitForSeconds(shotCooldown);

        AllowedToShoot = true;
    }
}
