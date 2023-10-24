using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [Header("Spawning Data | Don't add the negative symbol")]
    public float spawnDis;
    public float MaxSpawnDis;
    public Vector2 lowest;
    public Vector2 highest;
    public bool AllowSpawn;

    public GameObject SpawnEffect;


    [SerializeField]
    private GameObject[] SpawnerPrefabs;


    public float interval = 3;






    // Start is called before the first frame update
    void Start()
    {
        //spawning is allowed at the beginning
        AllowSpawn = true;
    }

    private void Update()
    {
        //Every frame we see if we can spawn an enemy
        AttemptSpawn();
    }

    void AttemptSpawn()
    {

        //Get the player
        GameObject Player = GameObject.FindGameObjectWithTag("Player");

        //Get a random potential position for the enemy to spawn at
        Vector2 spawnPos = new Vector2(Random.Range(lowest.x, highest.x), Random.Range(lowest.y, highest.y));

        //Check the distance between our random position and the player
        float dis = Vector2.Distance(Player.transform.position, spawnPos);

        //If the spawn distance isn't too close to the player
        //And if the spawn isn't too far from the player
        if(dis > spawnDis && AllowSpawn && dis < MaxSpawnDis)
        {
            //If not too close and allowed to spawn, spawn enemy
            StartCoroutine(SpawnEnemy(spawnPos));
        }
    }


    private IEnumerator SpawnEnemy(Vector3 spawnPos)
    {

        //picking which enemy to spawn.
        int num = Random.Range(0, SpawnerPrefabs.Length);
        Debug.Log(num);
        
        GameObject newEnemy = Instantiate(SpawnerPrefabs[num], spawnPos, Quaternion.identity);
        Instantiate(SpawnEffect, spawnPos, Quaternion.identity);

        AllowSpawn = false;
        
        yield return new WaitForSeconds(interval);
        
        AllowSpawn = true;


        //Vector3 lastPosition = new Vector3(0, 0, 0);
        //Vector3 offsetVector = new Vector3(2, 2, 0);


    }
}

