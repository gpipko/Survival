using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrongEnemy : MonoBehaviour {

    public int life = 3;
    public int score = 50;
    public GameObject player;
    public AudioSource explosionSound;

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectsWithTag("Player")[0];
    }
	
	// Update is called once per frame
	void Update () {
        	
	}

    void shot()
    {
        life = life - 1;
        if (life <= 0)
        {
            explosionSound.Play();
            player.SendMessage("addScore", score);
            Destroy(gameObject);
        }
    }
}
