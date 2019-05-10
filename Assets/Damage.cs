using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Damage : MonoBehaviour {

    public Transform gunPosition;
    private int life = 3;
    private int level = 1;
    private int nextLevel = 100;
    private int score = 0;
    public GameObject EnemySpawner;
    public AudioSource explosionSound;
    public AudioSource hitSound;

    // Use this for initialization
    void Start () {
        Cursor.visible = false;
        GameObject.FindGameObjectsWithTag("LivesBar")[0].GetComponent<Text>().text = String.Concat("Lives: ", life.ToString());
        GameObject.FindGameObjectsWithTag("ScoreBoard")[0].GetComponent<Text>().text = String.Concat("Score: ", score.ToString());
        GameObject.FindGameObjectsWithTag("LevelBar")[0].GetComponent<Text>().text = String.Concat("Level: ", level.ToString());
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }

    // fire gun
    void FireGun()
    {
        // struct object that will hold our raycast information
        RaycastHit hit;

        // if we collide with an object with our raycast, spawn a portal there
        if (Physics.Raycast(gunPosition.position, gunPosition.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
        {
            if (hit.collider.gameObject.tag == "Enemy")
            {
                hit.collider.gameObject.SendMessage("shot");
                GameObject.FindGameObjectsWithTag("ScoreBoard")[0].GetComponent<Text>().text = String.Concat("Score: ", score.ToString());
            }
        }
    }

    void addScore (int value)
    {
        explosionSound.Play();
        score = score + value;
        checkLevel();
    }

    void checkLevel()
    {
        if (score >= nextLevel)
        {
            level = level + 1;
            nextLevel = (int)(nextLevel + nextLevel * 1.25);
            life = life + 1;
            GameObject.FindGameObjectsWithTag("LivesBar")[0].GetComponent<Text>().text = String.Concat("Lives: ", life.ToString());
            GameObject.FindGameObjectsWithTag("LevelBar")[0].GetComponent<Text>().text = String.Concat("Level: ", level.ToString());
            EnemySpawner.SendMessage("adjustTime", (int)((100 - level)/5));
        }
    }

    void OnTriggerEnter(Collider other)
    {
        hitSound.Play();
        other.SendMessage("destroySelf");
        life = life - 1;
        GameObject.FindGameObjectsWithTag("LivesBar")[0].GetComponent<Text>().text = String.Concat("Lives: ", life.ToString());
        if (life <= 0)
        {
            PlayerPrefs.SetString("Score", score.ToString());
            SceneManager.LoadScene("GameOverScene");
        }
    }
}
