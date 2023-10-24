using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossAttacks : MonoBehaviour
{

    public bool allowedToAttack = false;
    public bool attackBreak = false;

    public float interval = 1f;

    [Header("Tracking ball attack")]
    public GameObject magicBall;
    public int att1Damage;
    
    [Header("Spreadshot attack")]
    public GameObject spreadShot;
    public int att2Damage;

    [Header("Pillar Attack")]
    public int att3Damage;
    public float distanceMax = 4;
    public float distanceMin = -4;

    //Mohamed variables
    public GameObject Pillar;
    private Transform PlayerPos;
    private float xPos;
    private float yPos;
    private int PillarCount;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (allowedToAttack == true && attackBreak != true)
        {
            DecideAttack();
        }
    }


    public void DecideAttack()
    {
        int attackNum = Random.Range(0, 3);
        //int attackNum = 2;

        switch (attackNum)
        {
            case 0:
                //attack number 1
                Attack1();
                break;

            case 1:
                //attack number 2
                Attack2();
                break;

            case 2:
                //attack number 3
                Attack3();
                break;

        }

    }


    public void Attack1()
    {
        /*
        //set the direction of the attack
        var dir = GameObject.FindGameObjectWithTag("Player").transform.position - transform.position;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        var rotation = Quaternion.AngleAxis(angle, Vector3.forward);*/

        //create the attacking ball
        GameObject attackObj = Instantiate(magicBall, gameObject.transform.position, Quaternion.identity);
        attackObj.GetComponent<BossBullet>().damage = att1Damage;

        Destroy(attackObj, 5f);

        StartCoroutine(DelayAttack(interval+1));
        
    }

    public void Attack2()
    {
        //set the direction of the attack
        var dir = GameObject.FindGameObjectWithTag("Player").transform.position - transform.position;

        //create the particle system
        GameObject attackObj = Instantiate(spreadShot, gameObject.transform.position, Quaternion.LookRotation(dir));
        attackObj.GetComponent<bullet>().damage = att2Damage;

        StartCoroutine(DelayAttack(interval));
        
    }

    public void Attack3()
    {
        PlayerPos = GameObject.FindGameObjectWithTag("Player").transform;

        PillarCount = 0;
        while (PillarCount < 3)
        {
            xPos = PlayerPos.position.x + Random.Range(distanceMin, distanceMax);
            yPos = PlayerPos.position.y + Random.Range(distanceMin, distanceMax);

            GameObject newPillar = Instantiate(Pillar, new Vector3(xPos, yPos, 0), Quaternion.identity);
            newPillar.GetComponent<AnimationDelete>().damage = att3Damage;

            PillarCount += 1;
        }

        StartCoroutine(DelayAttack(interval));
    }



    public IEnumerator DelayAttack(float waitTime)
    {
        attackBreak = true;
        yield return new WaitForSeconds(waitTime);
        attackBreak = false;
    }
}
