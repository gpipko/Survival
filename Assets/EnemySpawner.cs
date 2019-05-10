using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public Transform playerLocation;
    public GameObject[] normalEnemies;
    public GameObject[] strongEnemies;
    public Transform[] sawnPostions;

    private int spawnTimer = 20;

    // Use this for initialization
    void Start () {
        StartCoroutine(SpawnEnemies());
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void adjustTime (int newTime)
    {
        if (newTime >= 1)
        {
            spawnTimer = newTime;
        }
        else
        {
            spawnTimer = 1;
        }
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            if (Random.Range(1,5) == 4)
            {
                GameObject tempObject = Instantiate(strongEnemies[Random.Range(0, strongEnemies.Length)], sawnPostions[Random.Range(0, sawnPostions.Length)].position, Quaternion.identity) as GameObject;
                tempObject.SendMessage("setPlayer", playerLocation);
            }
            else
            {
                GameObject tempObject = Instantiate(normalEnemies[Random.Range(0, normalEnemies.Length)], sawnPostions[Random.Range(0, sawnPostions.Length)].position, Quaternion.identity) as GameObject;
                tempObject.SendMessage("setPlayer", playerLocation);
            }

            yield return new WaitForSeconds(Random.Range(1, spawnTimer));
        }
    }
}
