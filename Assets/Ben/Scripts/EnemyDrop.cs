using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDrop : MonoBehaviour
{
    public static EnemyDrop Instance;

    public GameObject[] dropItems;

    public int chanceOfDrop;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DropLoot()
    {
        int randInt = Random.Range(0, chanceOfDrop+1);

        if(chanceOfDrop == randInt)
        {
            int itemRange = dropItems.Length;

            randInt = Random.Range(0, itemRange);

            Instantiate(dropItems[randInt], transform.position, Quaternion.identity);
        }
    }
}
