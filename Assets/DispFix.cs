using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DispFix : MonoBehaviour {

    public GameObject CameraObject;
    private int displayInt = 0;

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        if (displayInt == 0)
        {
            CameraObject.GetComponent<Camera>().allowMSAA = false;
            displayInt = 1;
        }
        else if (displayInt == 1)
        {
            CameraObject.GetComponent<Camera>().allowMSAA = true;
            displayInt = 0;
        }
	}
}
