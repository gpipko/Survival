using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiControl : MonoBehaviour {

    private static float speed = 4f;
    public Transform playerLocation;
    public AudioSource explosionSound;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        transform.LookAt(playerLocation.position);
        transform.Rotate(new Vector3(0, -90, 0), Space.Self);

        transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));

    }

    // set player
    public void setPlayer (Transform location)
    {
        playerLocation = location;
    }

    // destroy object
    public void destroySelf()
    {
        explosionSound.Play();
        Destroy(gameObject);
    }
}
