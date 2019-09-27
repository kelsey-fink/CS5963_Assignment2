using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR;

public class CameraReset : MonoBehaviour {

    public GameObject parentCam;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("tab"))
        {
            Vector3 currentPos = transform.position;
            Vector3 parentPos = parentCam.transform.position;
            currentPos = new Vector3(parentPos.x - currentPos.x, parentPos.y - currentPos.y, parentPos.z - currentPos.z);
            parentCam.transform.position = currentPos;
        }
    }
}
