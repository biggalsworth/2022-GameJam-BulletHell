using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public static PlayerBullet instance;


    //public Vector3 targetPos;

    public Rigidbody2D rb;

    [Header("bullet Stats")]
    public float damage;
    public float speed = 7f;

    public Material skin;
    public Material raySkin;

    private float count;

    [Header("bullet explosion")]
    public AudioClip explosion;

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        //The bullet aiming is handled by the player object

        //move forward
        rb.AddForce(transform.right, ForceMode2D.Force);

        //float mat = skin.GetFloat("Pos");

        //Vector2 newPos = new Vector2(mat.x + 1, mat.y + 1);

        count += 0.75f;

        skin.SetFloat("_Pos", count*Time.deltaTime);
        skin.SetFloat("_Rot", count*Time.deltaTime);

        float currValue = raySkin.GetFloat("_Pos");

        raySkin.SetFloat("_Pos", currValue+0.5f * Time.deltaTime);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject hit = collision.gameObject;
        if(hit.tag == "Enemy")
        {
            hit.GetComponent<Enemy_Stats>().TakeDamage(damage += PlayerStats.damageIncrease);

            //Add the explosion sound game object
            GameObject explode = new GameObject();
            explode.name = "explodeSound";
            explode.AddComponent<AudioSource>();
            explode.GetComponent<AudioSource>().clip = explosion;
            explode.GetComponent<AudioSource>().Play();

            Destroy(explode,5f);
        }
    }
}
