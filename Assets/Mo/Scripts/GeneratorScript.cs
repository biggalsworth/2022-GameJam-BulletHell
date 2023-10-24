using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorScript : MonoBehaviour
{ //Calling outa bunch of Game objects and variables such as The Enenmy we want to spawn
  // The Boss we need alive for the script to run and the players position
  //The xPos and the yPos and the EnemyCount are all things that the script keeps track of
  //Like where the creatures are spawning and how many have spawned so far
    public GameObject TheEnemy;
    public GameObject Boss;
    public Transform Player;
    public float xPos;
    public float yPos;
    public int EnemyCount;
    
    void Start()
    {//This calls out the enemy Drop function which is the actrual code that does the spawning
        EnemyDrop();
    }
    public void EnemyDrop()
    { //The following code starts the count at 0 and then starts spawning in th game object we declared as the Enenmy
        int count = 0;
        while (count < 3 && Boss != null)
        { //The code above is a sanity check that makes sure that the count needs to be greater then 3 and the boss needs to be alive
            xPos = Player.transform.position.x + Random.Range(-4, 4);
            yPos = Player.transform.position.y + Random.Range(-4, 4);
            //This code above takes the players position and adds a range between -4 and 4 to spawn in the enemy which in turn sets our possible area for the 
            //attack to spawn in.
            GameObject newPillar = Instantiate(TheEnemy, new Vector3(xPos, yPos, 0), Quaternion.identity);
            count += 1;
        } //The code above is the code that does the actual spawning in of the entity and calls on the range we set earlier to find a spot to spawn it in.
    }
}
