using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KillCounter : MonoBehaviour
{
    public static KillCounter Instance;

    public int kill_counter;

    public int maxKills;

    [Header("UI Variables")]
    public Slider gameCounterTracker;
    public GameObject sliderObject;
    public GameObject ColourFill;

    [Header("Boss")]
    public GameObject Boss;
    public GameObject BossSlider;
    public GameObject BossNotice;
    public AudioSource MainSound;
    public float maxDistance = 10;
    public float RequiredDist = 5;
    private float spawnDisMin;
    private bool BossSpawned = false;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        kill_counter = 0;
        gameCounterTracker.maxValue = maxKills;

        ColourFill.SetActive(false);

        //Make the mininum spawn distance the negative of the maximum
        spawnDisMin = maxDistance * -1;
    }

    // Update is called once per frame
    void Update()
    {
        if (kill_counter > 0 && !ColourFill.activeSelf)
        {
            ColourFill.SetActive(true);
        }

        gameCounterTracker.value = kill_counter; 

        //If the player has killed all enemies for this level.
        //Spawn the boss
        if(kill_counter >= maxKills && !BossSpawned)
        {
            //When the boss spawns, keep spawning enemies but at a slower rate.
            GameObject spawner = GameObject.Find("Spawner");
            spawner.GetComponent<EnemySpawner>().interval = 10f;

            //Hide Level Progression Bar
            sliderObject.SetActive(false);
            //SpawnBoss
            StartCoroutine(SpawnBoss());
            BossSpawned = true;
        }
    }


    public IEnumerator SpawnBoss()
    {
        Vector3 BossSpawnLocation;

        Transform Player = GameObject.FindGameObjectWithTag("Player").transform;

        //loop until you found a position thats not too close to player
        while (true)
        {
            float posX = Random.Range(spawnDisMin, maxDistance);
            float posY = Random.Range(spawnDisMin, maxDistance);

            BossSpawnLocation = new Vector3(posX, posY, 0);

            float distance = Vector2.Distance(Player.position, BossSpawnLocation);
            
            //If the distance between the player and the potential spawn position is far enough
            if(distance > RequiredDist)
            {
                //Stop looking for positions
                break;
            }
        }

        BossSlider.SetActive(true);

        BossNotice.SetActive(true);
        Instantiate(Boss, BossSpawnLocation, Quaternion.identity);
        MainSound.Play();

        yield return new WaitForSeconds(5f);
        BossNotice.SetActive(false);
    }


    public void CounterIncrease()
    {
        kill_counter++;
    }
}
